namespace CarpetFactory;

class CityGraph
{
    private const int INF = 10000;
    private List<Vertex> vertices;
    public int[,] adjMatrix;
    private int size;

    public List<Vertex> Vertices
    {
        get { return vertices; }
    }

    public int Size
    {
        get { return vertices.Count; }
    }


    public CityGraph(int initialSize)
    {
        if (size < 0)
        {
            throw new ArgumentException("Number of vertices cannot be negative");
        }

        size = initialSize;
        vertices = new List<Vertex>(initialSize);
        adjMatrix = new int[initialSize, initialSize];
        for (int i = 0; i < initialSize; i++)
        {
            vertices[i] = new Vertex(i, new List<Vertex>());
        }
    }

    public CityGraph()
    {
        vertices = new List<Vertex>();
        adjMatrix = new int[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == j) adjMatrix[i, j] = 0;
                else adjMatrix[i, j] = INF;
            }
        }

        vertices.Add(new Vertex(0, 1, 5));
        vertices.Add(new Vertex(1, 3, 5));
        vertices.Add(new Vertex(2, 5, 5));
        vertices.Add(new Vertex(3, 1, 3));
        vertices.Add(new Vertex(4, 3, 3));
        vertices.Add(new Vertex(5, 5, 3));
        vertices.Add(new Vertex(6, 1, 1));
        vertices.Add(new Vertex(7, 3, 1));
        vertices.Add(new Vertex(8, 5, 1));
        vertices.Add(new Vertex(9, 7, 3));


        vertices[0].isCarpetBranch = true;
        vertices[3].isCarpetBranch = true;
        vertices[4].isCarpetBranch = true;
        vertices[6].isCarpetBranch = true;
        vertices[9].isCarpetBranch = true;
        // Random random = new Random();
        // ISet<int> set = new HashSet<int>();
        // while (set.Count < 5)
        // {
        //     int r = random.Next(0, 10);
        //     set.Add(r);
        //     var branchVertex = vertices.ToList().Where(v => v.Value == r).FirstOrDefault();
        //     branchVertex.isCarpetBranch = true;
        // }

        AddEdge(vertices[0], vertices[1], 10);
        AddEdge(vertices[0], vertices[3], 10);
        AddEdge(vertices[1], vertices[4], 10);
        AddEdge(vertices[1], vertices[2], 10);
        AddEdge(vertices[2], vertices[5], 1);
        AddEdge(vertices[2], vertices[9], 1);
        AddEdge(vertices[3], vertices[4], 1);
        AddEdge(vertices[3], vertices[6], 1);
        AddEdge(vertices[4], vertices[7], 1);
        AddEdge(vertices[5], vertices[8], 1);
        AddEdge(vertices[6], vertices[7], 1);
        AddEdge(vertices[8], vertices[9], 1);
        // graph:
    }

    public CityGraph(List<Vertex> initialNodes)
    {
        vertices = initialNodes;
        adjMatrix = new int[initialNodes.Count, initialNodes.Count];
        size = vertices.Count;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                adjMatrix[i, j] = 0;
            }
        }
    }

    public void AddVertex(Vertex vertex)
    {
        vertices.Add(vertex);
    }

    public void RemoveVertex(Vertex vertex)
    {
        vertices.Remove(vertex);
    }

    public bool HasVertex(Vertex vertex)
    {
        return vertices.Contains(vertex);
    }


    public void AddEdge(Vertex v1, Vertex v2, int weight)
    {
        v1.Neighbors.Add(v2);
        v2.Neighbors.Add(v1);
        adjMatrix[v1.Value, v2.Value] = weight;
        adjMatrix[v2.Value, v1.Value] = weight;
    }

    public void RemoveEdge(Vertex v1, Vertex v2)
    {
        v1.Neighbors.Remove(v2);
        v2.Neighbors.Remove(v1);
        adjMatrix[v1.Value, v2.Value] = 0;
        adjMatrix[v2.Value, v1.Value] = 0;
    }

    public void DepthFirstSearch(Vertex root)
    {
        if (!root.IsVisited)
        {
            Console.Write(root.Value + " ");
            root.Visit();

            foreach (Vertex neighbor in root.Neighbors)
            {
                DepthFirstSearch(neighbor);
            }
        }
    }

    public void BreadthFirstSearch(Vertex root)
    {
        Queue<Vertex> queue = new Queue<Vertex>();

        root.Visit();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Vertex current = queue.Dequeue();

            foreach (Vertex neighbor in current.Neighbors)
            {
                if (!neighbor.IsVisited)
                {
                    Console.Write(neighbor.Value + " ");
                    neighbor.Visit();
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}