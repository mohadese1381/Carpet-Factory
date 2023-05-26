namespace CarpetFactory;

public class FactoryManager
{
    static public int V;

    static private List<Carpet> carpets = new List<Carpet>();

    static private CityGraph _cityGraph = new CityGraph(10); 

    private static int[,] path;

    private static  int[,] distance;
    public static int VerticesCount { get; set; }

    //----------------------------------------------M-Coloring
    //Function to display
    static void Display(int[] color)
    {
        Console.WriteLine("Solution Exists \n The colors given to vertices are:");
        for (int i = 0; i < V; i++)
            Console.WriteLine("Vertex " + (i + 1) + " is given color:" + color[i]);
        Console.WriteLine();
    }


    //Function to check constraints
    static bool satisfyConstraints(bool[,] Adj_matrix, int[] color)
    {
        for (int i = 0; i < V - 1; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                if (Adj_matrix[i, j] && color[j] == color[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    //Function for m-coloring problem
    static public bool m_Coloring(bool[,] Adj_matrix, int m, int i, int[] color)
    {
        // if current index reached end
        if (i == V)
        {
            // if constraint is satisfied
            if (satisfyConstraints(Adj_matrix, color))
            {
                Display(color);
                return true;
            }

            return false;
        }


        // Assign each color from 1 to m
        for (int j = 1; j <= m; j++)
        {
            color[i] = j;
            // For the rest of the vertices
            if (m_Coloring(Adj_matrix, m, i + 1, color))
                return true;
            color[i] = 0;
        }

        return false;
    }

    //----------------------------------------------KnapSack
    public static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
    {
        int carpetCounter = 0;
        int[,] K = new int[itemsCount + 1, capacity + 1];

        for (int i = 0; i <= itemsCount; ++i)
        {
            for (int j = 0; j <= capacity; ++j)
            {
                if (i == 0 || j == 0)
                    K[i, j] = 0;
                else if (weight[i - 1] <= j)
                {
                    K[i, j] = Math.Max(value[i - 1] + K[i - 1, j - weight[i - 1]], K[i - 1, j]);
                }

                else
                    K[i, j] = K[i - 1, j];
            }
        }

        int res = K[itemsCount, capacity];
        int w = capacity;
        for (int k = itemsCount; k > 0 && res > 0; k--)
        {
            if (res == K[k - 1, w])
                continue;
            else
            {
                carpetCounter++;
                res = res - value[k - 1];
                w = w - weight[k - 1];
            }
        }

        return carpetCounter;
    }

    //fill the carpet value---------------------------------------------------------
    private static int val = (carpets.Count + 1);

    public static void FillCarpetValue()
    {
        carpets.OrderBy(x => x.Price).ToList().ForEach(x => x.Value = --val);
    }

    //Floyd algorithm------------------------------------------------------------------
    private const int INF = 10000;

    private static void disp(int[,] distance, int verticesCount)
    {
        Console.WriteLine("Distance Matrix for Shortest Distance between the nodes");
        Console.Write("\n");

        for (int i = 0; i < verticesCount; ++i)
        {
            for (int j = 0; j < verticesCount; ++j)
            {
                // IF THE DISTANCE TO THE NODE IS NOT DIRECTED THAN THE COST IN iNIFINITY  

                if (distance[i, j] == INF)
                    Console.Write("INF".PadLeft(7));
                else
                    Console.Write(distance[i, j].ToString().PadLeft(7));
            }

            Console.WriteLine();
        }
    }

    public static void FloydWarshall(int[,] graph, int verticesCount)
    { 
        distance = new int[verticesCount, verticesCount];
        path = new int[verticesCount, verticesCount];
        VerticesCount = verticesCount;
        for(int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                //path[i,j] = graph[i, j] == INF ? -1 : j;
                path[i, j] = -1;
            }
        }
        
        for (int i = 0; i < verticesCount; ++i)
            for (int j = 0; j < verticesCount; ++j)
                 distance[i, j] = graph[i, j];

        for (int k = 0; k < verticesCount; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (distance[i, k] + distance[k, j] < distance[i, j])
                    {
                        distance[i, j] = distance[i, k] + distance[k, j];
                        path[i, j] = k;
                    }
                }
            }
        }

    }
   
        static List<int> closeVertices(int u, int v)
        {
     
            // If there's no path between
            // node u and v, simply return
            // an empty array
            if (path[u, v] == -1)
                return null;
 
            // Storing the path in a vector
            List<int> resultPath = new List<int>();
            resultPath.Add(u);
     
            while (u != v)
            {
                u = path[u, v];
                resultPath.Add(u);
            }
            return resultPath;
        }
        //--------------------
        /*
          static void GetPath(int u, int v,List<int> shortestPath)
         {
         if (path[u, v] != 0)
        {
            GetPath(u,path[u,v],shortestPath);
            shortestPath.Add(path[u,v]);
            GetPath(path[u,v],v,shortestPath);
        }*/

        
        static void GetClosestFactoryVertex(int x, int y)
        {
           
            int[] personLocCloseVertices = new int [VerticesCount];
            var personLoc = _cityGraph.Vertices.Where(c => c.x == x && c.y == y).FirstOrDefault();
            var index = _cityGraph.Vertices.IndexOf(personLoc);//u
            for (int i = 0; i < VerticesCount; i++)
            {
                personLocCloseVertices[i] = distance[index, i];
            }

            var min = personLocCloseVertices.ToList().Min();
            var index2 = personLocCloseVertices.ToList().IndexOf(min); //index of closest vertext
            var v = _cityGraph.Vertices[index2];
            var carpetBranchindex = v.isCarpetBranch ? index2 : -1;
            if(carpetBranchindex != -1)
                closeVertices(index, carpetBranchindex);
        }
}