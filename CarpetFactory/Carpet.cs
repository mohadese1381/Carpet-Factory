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
    private List<Dictionary<int,Colors>> allUsedColor = new List<Dictionary<int,Colors>>();
    private int[,] carpetMatrix = new int[300, 400];
    
    public Carpet()
    {
        Id = RandomId;
    }

    public double CalculateTotalPrice()
    {
        return 0;
    }
}
enum Colors
{
    Blue = 1, Green, Black, White, Red, 
    Gray, Pink, Yellow, Purple, Brown
}