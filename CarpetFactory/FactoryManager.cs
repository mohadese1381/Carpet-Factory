namespace CarpetFactory;

public class FactoryManager
{
    static public int V;

    static private List<Carpet> carpets = new List<Carpet>();
    //Function to display

    static void Display(int[] color)
    {
        Console.WriteLine("Solution Exists \n The colors given to vertices are:");
        for (int i = 0; i < V; i++)
            Console.WriteLine("Vertex " + (i + 1) + " is given color:" + color[i]);
        Console.WriteLine();
    }


    //Function to check constraints
    static bool satisfyConstraints(bool[,] Adj_matrix, int[] color)
    {
        for (int i = 0; i < V-1; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                if (Adj_matrix[i, j] && color[j] == color[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    //Function for m-coloring problem
    static public bool m_Coloring(bool[,] Adj_matrix, int m, int i, int[] color)
    {
        // if current index reached end
        if (i == V)
        {
            // if constraint is satisfied
            if (satisfyConstraints(Adj_matrix, color))
            {
                Display(color);
                return true;
            }

            return false;
        }


        // Assign each color from 1 to m
        for (int j = 1; j <= m; j++)
        {
            color[i] = j;
            // For the rest of the vertices
            if (m_Coloring(Adj_matrix, m, i + 1, color))
                return true;
            color[i] = 0;
        }

        return false;
    }
}