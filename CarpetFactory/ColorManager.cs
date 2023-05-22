namespace CarpetFactory;

public class ColorManager
{
    private List<Dictionary<int,Colors>> allColors = new List<Dictionary<int,Colors>>();

    public ColorManager()
    {
        
    }

    public int GetKey(string color)
    {
        return 0;
    }
    
    public string GetColor(int key)
    {
        return string.Empty;
    }
}
enum Colors
{
    Blue = 1, Green, Black, White, Red, 
    Gray, Pink, Yellow, Purple, Brown
}