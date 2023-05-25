// See https://aka.ms/new-console-template for more information

using CarpetFactory;

//test of m-coloring-------------------------------------------------------
// UndirectedGenericGraph graph = new UndirectedGenericGraph(4);
//
// graph.AddVertex(new Vertex(0));
// graph.AddVertex(new Vertex(1));
// graph.AddVertex(new Vertex(2));
// graph.AddVertex(new Vertex(3));
//
// graph.AddEdge(graph.Vertices[0], graph.Vertices[1]);
// graph.AddEdge(graph.Vertices[0], graph.Vertices[3]);
// graph.AddEdge(graph.Vertices[1], graph.Vertices[2]);
// graph.AddEdge(graph.Vertices[1], graph.Vertices[3]);
// graph.AddEdge(graph.Vertices[2], graph.Vertices[3]);
//
// FactoryManager.V = 4;
// Console.WriteLine(graph.AdjMatrix.Length);
// int[] colors = new int[graph.Size];
// FactoryManager.m_Coloring(graph.AdjMatrix, 3, 0, colors);

int numVertices = 5;
Graph graph = new Graph(numVertices);
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 3);
graph.AddEdge(3, 4);

int[] colors = new int[numVertices];
for (int i = 0; i < numVertices; i++)
{
    colors[i] = -1; // Initialize all colors to -1 (unassigned)
}

int numColors = 3; // Maximum number of colors to use
if (graph.ColorGraph(0, colors, numColors))
{
    Console.WriteLine("Vertex Color");
    for (int i = 0; i < numVertices; i++)
    {
        Console.WriteLine(i + "  ->  " + colors[i]);
    }
}
else
{
    Console.WriteLine("No valid coloring found");
}

//test of knapsack-------------------------------------------------------
int[] value = { 10, 50, 70 };
int[] weight = { 10, 20, 30 };
int capacity = 40;
int itemsCount = 3;

int result = FactoryManager.KnapSack(capacity, weight, value, itemsCount);
Console.WriteLine("Knapsack result : " + result);