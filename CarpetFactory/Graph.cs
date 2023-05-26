namespace CarpetFactory;

public class Graph
{
    public int NumVertices { get; }
    public List<int>[] adjList;
    public int[,] adjMatrix;

    public Graph(int numVertices)
    {
        NumVertices = numVertices;
        adjMatrix = new int[numVertices, numVertices];
        adjList = new List<int>[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjList[u].Add(v);
        adjList[v].Add(u);
        adjMatrix[u, v] = 1;
        adjMatrix[v, u] = 1;
    }
}