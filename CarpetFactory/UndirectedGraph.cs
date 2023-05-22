namespace CarpetFactory;

class UndirectedGenericGraph<T>
{

    // The list of vertices in the graph
    private List<Vertex<T>> vertices;

    // The number of vertices
    int size;

    public List<Vertex<T>> Vertices { get { return vertices; } }
    public int Size { get { return vertices.Count; } }


    public UndirectedGenericGraph(int initialSize)
    {
        if(size < 0)
        {
            throw new ArgumentException("Number of vertices cannot be negative");
        }

        size = initialSize;

        vertices = new List<Vertex<T>>(initialSize);

    }

    public UndirectedGenericGraph(List<Vertex<T>> initialNodes)
    {
        vertices = initialNodes;
        size = vertices.Count;
    }

    public void AddVertex(Vertex<T> vertex)
    {
        vertices.Add(vertex);
    }

    public void RemoveVertex(Vertex<T> vertex)
    {
        vertices.Remove(vertex);
    }

    public bool HasVertex(Vertex<T> vertex)
    {
        return vertices.Contains(vertex);
    }

    public void DepthFirstSearch(Vertex<T> root)
    {
        if (!root.IsVisited)
        {
            Console.Write(root.Value + " ");
            root.Visit();

            foreach(Vertex<T> neighbor in root.Neighbors)
            {
                DepthFirstSearch(neighbor);
            }
        }
    }
    
    public void BreadthFirstSearch(Vertex<T> root)
    {
        Queue<Vertex<T>> queue = new Queue<Vertex<T>>();

        root.Visit();

        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            Vertex<T> current = queue.Dequeue();

            foreach (Vertex<T> neighbor in current.Neighbors)
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