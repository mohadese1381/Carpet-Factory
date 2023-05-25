// See https://aka.ms/new-console-template for more information

using CarpetFactory;
//test of m-coloring-------------------------------------------------------
UndirectedGenericGraph graph = new UndirectedGenericGraph(4);

graph.AddVertex(new Vertex(0));
graph.AddVertex(new Vertex(1));
graph.AddVertex(new Vertex(2));
graph.AddVertex(new Vertex(3));

graph.AddEdge(graph.Vertices[0], graph.Vertices[1]);
graph.AddEdge(graph.Vertices[0], graph.Vertices[3]);
graph.AddEdge(graph.Vertices[1], graph.Vertices[2]);
graph.AddEdge(graph.Vertices[1], graph.Vertices[3]);
graph.AddEdge(graph.Vertices[2], graph.Vertices[3]);

FactoryManager.V = 4;
Console.WriteLine(graph.AdjMatrix.Length);
int[] colors = new int[graph.Size];
FactoryManager.m_Coloring(graph.AdjMatrix, 3, 0, colors);

//test of knapsack-------------------------------------------------------
int[] value = { 10, 50, 70 };
int[] weight = { 10, 20, 30 };
int capacity = 40;
int itemsCount = 3;

int result = FactoryManager.KnapSack(capacity, weight, value, itemsCount);
Console.WriteLine("Knapsack result : "+result);