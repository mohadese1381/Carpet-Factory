namespace CarpetFactory;

class Graph
{
    private int numVertices;
    private List<int>[] adjList;

    public Graph(int numVertices)
    {
        this.numVertices = numVertices;
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
    }

    public bool ColorGraph(int vertex, int[] colors, int numColors)
    {
        if (vertex == numVertices) // All vertices have been colored
        {
            return true;
        }

        // Try all possible colors
        for (int i = 0; i < numColors; i++)
        {
            if (IsValidColor(vertex, colors, i))
            {
                colors[vertex] = i;

                // Recursively color the remaining vertices
                if (ColorGraph(vertex + 1, colors, numColors))
                {
                    return true;
                }

                // If we can't color the remaining vertices with this color, backtrack
                colors[vertex] = -1;
            }
        }

        return false;
    }

    private bool IsValidColor(int vertex, int[] colors, int color)
    {
        // Check if any adjacent vertices have the same color
        foreach (int adjVertex in adjList[vertex])
        {
            if (colors[adjVertex] == color)
            {
                return false;
            }
        }

        return true;
    }
}