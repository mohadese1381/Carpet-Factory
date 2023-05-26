namespace CarpetFactory;

public class Carpet
{
    private static int idCounter;
    public int Id { get; }
    public int Price { get; set; }
    public int Value { get; set; }
    private List<int> allUsedColor;
    private int[,] carpetMatrix;

    public Carpet()
    {
        Id = ++idCounter;
        allUsedColor = new List<int>();
        carpetMatrix = new int[30, 40];

        Random random = new Random();
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 40; j += 10)
            {
                int color = random.Next(0, 10);
                for (int k = j; k < j + 10; k++)
                {
                    carpetMatrix[i, k] = color;
                }

                if (!allUsedColor.Contains(carpetMatrix[i, j]))
                    allUsedColor.Add(carpetMatrix[i, j]);
            }
        }

        CalculateTotalPrice();
    }

    private void CalculateTotalPrice()
    {
        Price = 0;
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Price += carpetMatrix[i, j];
            }
        }
    }

    public int[,] CarpetMatrix
    {
        get { return carpetMatrix; }
    }

    public override string ToString()
    {
        return "Carpet id: " + Id + " - Price: " + Price;
    }
}