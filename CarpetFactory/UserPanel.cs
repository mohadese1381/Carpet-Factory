namespace CarpetFactory;

public class UserPanel
{
    public void showMenu()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("\n---- Please Select Service Number: -----");

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\t[1] Design New Carpet");
        Console.WriteLine("\t[2] Find Similar Carpets");
        Console.WriteLine("\t[3] Buy Carpets");
        Console.WriteLine("\t[4] Find Closest Branch");
        Console.WriteLine("\t[5] Show All Carpets");
        Console.WriteLine("\t[0] Exit");
        Console.Write("-> ");

        int selection = Convert.ToInt32(Console.ReadLine());

        switch (selection)
        {
            case 0:
                System.Environment.Exit(1);
                break;
            case 1:
                ColoringGraph();
                break;
            case 2:

                break;
            case 3:
                BuyCarpets();
                break;
            case 4:
                ClosestBranch();
                break;
            case 5:
                ShowAllCapets();
                break;
            default:
                Console.WriteLine("Invalid Number");
                break;
        }
    }

    private void ColoringGraph()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter Number of Shapes:");
        int shapes = Convert.ToInt32(Console.ReadLine());
        Graph graph = new Graph(shapes);

        int u, v;
        Console.WriteLine(
            $"Enter Connected Shapes in One Line: (Indexes Can Be Between 0 and {shapes - 1})\n[Enter -1 for End]");
        String line;
        while (true)
        {
            line = Console.ReadLine();
            if (line == "-1") break;

            String[] split = line.Split(" ");
            u = Convert.ToInt32(split[0]);
            v = Convert.ToInt32(split[1]);
            graph.AddEdge(u, v);
        }

        int[] colors = new int[shapes];
        FactoryManager.ColorGraph(graph, 0, colors, 10);
        ISet<int> colorSet = new HashSet<int>(colors);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Minimum Number of Required Colors is:" + colorSet.Count);
        Console.WriteLine("Colored Shapes:");
        DisplayColoredText(colors);
    }

    private void DisplayColoredText(int[] colors)
    {
        for (int index = 0; index < colors.Length; index++)
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
        }
    }

    private void BuyCarpets()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the Money You Can Afford:");
        int money = Convert.ToInt32(Console.ReadLine());
        int[] prices = FactoryManager.allCarpets.Select(x => x.Price).ToArray();
        int[] values = FactoryManager.allCarpets.Select(x => x.Value).ToArray();

        List<Carpet> result = FactoryManager.KnapSack(money, prices, values, FactoryManager.allCarpets.Count);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Number of Carpets You Can Afford: " + result.Count);
        Console.WriteLine("Carpets You Can Buy:");
        foreach (var cr in result)
        {
            Console.WriteLine($"carpet: id {cr.Id} with price {cr.Price}");
        }
    }

    private void ClosestBranch()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter Your Location:");
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        List<int> path = FactoryManager.GetClosestFactoryVertex(x, y);
        if (path.Count == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("There is a Branch in Your Location Now!");
        }
        else
        {
            Console.WriteLine("You Are in Intersection " + path[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Closest Branch to Your Location is: " + path[path.Count - 1]);
            Console.WriteLine("You Can Follow This Path to Get to The Closest Branch:");
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i]);
                if (i != path.Count - 1) Console.Write(" -> ");
            }
        }
    }

    private void ShowAllCapets()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Our Carpets:");
        foreach (Carpet c in FactoryManager.allCarpets)
        {
            Console.WriteLine(c);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Select The Id of Carpet to Show it:");
        int id = Convert.ToInt32(Console.ReadLine());
        Carpet carpet = FactoryManager.allCarpets.Find(c => c.Id == id);
        if (carpet == null)
            Console.WriteLine("There is No Carpet With This Id!");
        else
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Console.ForegroundColor = FindColor(carpet.CarpetMatrix[i, j]);
                    Console.Write("■");
                }

                Console.WriteLine();
            }
        }
    }

    private ConsoleColor FindColor(int i)
    {
        switch (i)
        {
            case 0:
                return ConsoleColor.Blue;
            case 1:
                return ConsoleColor.Green;
            case 2:
                return ConsoleColor.Black;
            case 3:
                return ConsoleColor.White;
            case 4:
                return ConsoleColor.Red;
            case 5:
                return ConsoleColor.Gray;
            case 6:
                return ConsoleColor.Magenta;
            case 7:
                return ConsoleColor.Yellow;
            case 8:
                return ConsoleColor.DarkMagenta;
            case 9:
                return ConsoleColor.Cyan;
            default:
                return ConsoleColor.DarkBlue;
        }
    }
}