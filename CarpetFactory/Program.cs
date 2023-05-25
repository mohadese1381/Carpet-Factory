// See https://aka.ms/new-console-template for more information

using CarpetFactory;

//test of m-coloring-------------------------------------------------------
// CityGraph graph = new CityGraph(4);
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
        DisplayColoredText(i);
    }
}
else
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("No valid coloring found");
}

//test of knapsack-------------------------------------------------------
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
int[] value = { 10, 50, 70 };
int[] weight = { 10, 20, 30 };
int capacity = 40;
int itemsCount = 3;

int result = FactoryManager.KnapSack(capacity, weight, value, itemsCount);
Console.WriteLine("Knapsack result : " + result);

void DisplayColoredText(int index)
{
    var resultColor = colors[index];
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(index + "  ->  ");
    switch (resultColor)
    {
        case 0:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("■■■■");
            break;
        case 1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■■■■");
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("■■■■");
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("■■■■");
            break;
        case 4:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■■■■");
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("■■■■");
            break;
        case 6:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("■■■■");
            break;
        case 7: 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■■■");
            break;
        case 8:
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("■■■■");
            break;
        case 9:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■■■■");
            break;
    }
    Console.WriteLine();
}