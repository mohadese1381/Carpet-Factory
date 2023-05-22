namespace CarpetFactory;

class UndirectedGenericGraph
{
    // The list of vertices in the graph
    private List<Vertex> vertices;
    private bool[,] adjMatrix;

    public bool[,] AdjMatrix
    {
        get { return adjMatrix; }
        set
        {
            adjMatrix = value;
        }
    }

// The number of vertices
    int size;

    public List<Vertex> Vertices
    {
        get { return vertices; }
    }

    public int Size
    {
        get { return vertices.Count; }
    }


    public UndirectedGenericGraph(int initialSize)
    {
        if (size < 0)
        {
            throw new ArgumentException("Number of vertices cannot be negative");
        }

        size = initialSize;
        vertices = new List<Vertex>(initialSize);
        adjMatrix = new bool[initialSize, initialSize];
    }

    public UndirectedGenericGraph(List<Vertex> initialNodes)
    {
        vertices = initialNodes;
        adjMatrix = new bool[initialNodes.Count, initialNodes.Count];
        size = vertices.Count;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                adjMatrix[i, j] = false;
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


    public void AddEdge(Vertex v1, Vertex v2)
    {
        v1.Neighbors.Add(v2);
        v2.Neighbors.Add(v1);
        adjMatrix[v1.Value, v2.Value] = true;
        adjMatrix[v2.Value, v1.Value] = true;
    }

    public void RemoveEdge(Vertex v1, Vertex v2)
    {
        v1.Neighbors.Remove(v2);
        v2.Neighbors.Remove(v1);
        adjMatrix[v1.Value, v2.Value] = false;
        adjMatrix[v2.Value, v1.Value] = false;
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