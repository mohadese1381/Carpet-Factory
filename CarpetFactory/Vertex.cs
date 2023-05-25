using System.Text;

namespace CarpetFactory;

class Vertex
{
    private List<Vertex> neighbors;   
    int value;
    public bool isCarpetBranch { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    bool isVisited;

    public List<Vertex> Neighbors { get { return neighbors; } set { neighbors = value; } }
    public int Value { get { return value; } set { this.value = value; } }
    public bool IsVisited { get { return isVisited; } set { isVisited = value; } }
    public int NeighborsCount { get { return neighbors.Count; } }

    public Vertex(int value)
    {
        this.value = value;
        isVisited = false;
        neighbors = new List<Vertex>();
    }

    public Vertex(int value, List<Vertex> neighbors)
    {
        this.value = value;
        isVisited = false;
        this.neighbors = neighbors;
    }

    public void Visit()
    {
        isVisited = true;
    }

    public override string ToString()
    {

        StringBuilder allNeighbors = new StringBuilder("");
        allNeighbors.Append(value + ": ");

        foreach (Vertex neighbor in neighbors)
        {
            allNeighbors.Append(neighbor.value + "  ");
        }

        return allNeighbors.ToString();

    }

}