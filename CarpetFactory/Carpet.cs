namespace CarpetFactory;

public class Carpet
{
    public int Id { get; set; }
    public static int RandomId
    {
        get { return ++RandomId;}
        private set { value = 0;} 
    }
    public double Price { get; set; }
    private List<Colors> allUsedColor = new List<Colors>();
    private int[,] carpetMatrix = new int[300, 400];
    private UndirectedGenericGraph carpetGraph;

    public Carpet()
    {
        Id = RandomId;
    }
    public double CalculateTotalPrice()
    {
        Price = 0;
        for (int i = 0; i < 300; i++)
        {
            for (int j = 0; j < 400; j++)
            {
                Price += carpetMatrix[i, j] * 10;
            }
        }
        return Price;
    }
}
