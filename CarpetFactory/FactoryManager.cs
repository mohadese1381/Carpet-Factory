namespace CarpetFactory;

public class FactoryManager
{
    public static List<Carpet> allCarpets = new List<Carpet>();
    private static int[,] Next;
    private static int[,] distance;
    private static CityGraph cityGraph = new CityGraph();
    private static int verticesCount;

    //----------------------------------------------M-Coloring
    public static bool ColorGraph(Graph graph, int vertex, int[] colors, int numColors)
    {
        if (vertex == graph.NumVertices) // All vertices have been colored
        {
            return true;
        }

        // Try all possible colors
        for (int i = 0; i < numColors; i++)
        {
            if (IsValidColor(graph, vertex, colors, i))
            {
                colors[vertex] = i;

                // Recursively color the remaining vertices
                if (ColorGraph(graph, vertex + 1, colors, numColors))
                {
                    return true;
                }

                // If we can't color the remaining vertices with this color, backtrack
                colors[vertex] = -1;
            }
        }

        return false;
    }

    private static bool IsValidColor(Graph graph, int vertex, int[] colors, int color)
    {
        // Check if any adjacent vertices have the same color
        foreach (int adjVertex in graph.adjList[vertex])
        {
            if (colors[adjVertex] == color)
            {
                return false;
            }
        }

        return true;
    }

    //----------------------------------------------KnapSack
    public static List<Carpet> KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
    {
        FillCarpetValue();
        int carpetCounter = 0;
        List<Carpet> carpetsCanBuy = new List<Carpet>();
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
                carpetsCanBuy.Add(FactoryManager.allCarpets[k - 1]);
                res = res - value[k - 1];
                w = w - weight[k - 1];
            }
        }

        return carpetsCanBuy;
    }

    private static void FillCarpetValue()
    {
        int val = (allCarpets.Count + 1);
        allCarpets.OrderBy(x => x.Price).ToList().ForEach(x => x.Value = --val);
    }

    //----------------------------------------------Floyd-Warshal
    private const int INF = 10000;

    private static void FloydWarshall(int[,] graph, int verticesCount)
    {
        distance = new int[verticesCount, verticesCount];
        Next = new int[verticesCount, verticesCount];
        FactoryManager.verticesCount = verticesCount;

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                // No edge between node i and j
                if (graph[i, j] == INF)
                    Next[i, j] = -1;
                else
                    Next[i, j] = j;

                distance[i, j] = graph[i, j];
            }
        }

        for (int k = 0; k < verticesCount; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (distance[i, k] + distance[k, j] < distance[i, j])
                    {
                        distance[i, j] = distance[i, k] + distance[k, j];
                        Next[i, j] = Next[i, k];
                    }
                }
            }
        }
    }

    static List<int> ConstructPath(int u, int v)
    {
        // If there's no path between node u and v, simply return an empty array
        if (Next[u, v] == -1)
            return null;

        // Storing the path in a vector
        List<int> path = new List<int>();
        path.Add(u);

        while (u != v)
        {
            u = Next[u, v];
            path.Add(u);
        }

<<<<<<< HEAD
        
        static void GetClosestFactoryVertex(int x, int y)
        {
           
            int[] personLocCloseVertices = new int [VerticesCount];
            var personLoc = _cityGraph.Vertices.Where(c => c.x == x && c.y == y).FirstOrDefault();
            var index = _cityGraph.Vertices.IndexOf(personLoc);//u
            for (int i = 0; i < VerticesCount; i++)
            {
                personLocCloseVertices[i] = distance[index, i];
            }
=======
        return path;
    }

    public static List<int> GetClosestFactoryVertex(int x, int y)
    {
        FloydWarshall(cityGraph.adjMatrix, cityGraph.Size);

        int[] personLocCloseVertices = new int [verticesCount];
        var personLoc = cityGraph.Vertices.Where(c => c.x == x && c.y == y).FirstOrDefault();
        var index = cityGraph.Vertices.IndexOf(personLoc); //u
        for (int i = 0; i < verticesCount; i++)
        {
            personLocCloseVertices[i] = distance[index, i];
        }
>>>>>>> 15b727df830d9ff01ed65919dc58f9641cbe07dd

        var carpetBranchIndex = -1;
        do
        {
            var min = personLocCloseVertices.ToList().Min();
            var index2 = personLocCloseVertices.ToList().IndexOf(min); //index of closest vertex
            var v = cityGraph.Vertices[index2];
            carpetBranchIndex = v.isCarpetBranch ? index2 : -1;
            // if (carpetBranchIndex == -1) personLocCloseVertices.ToList().Remove(min);
            if (carpetBranchIndex == -1) personLocCloseVertices[index2] = Int32.MaxValue;
        } while (carpetBranchIndex == -1);

        return ConstructPath(index, carpetBranchIndex);
    }
}