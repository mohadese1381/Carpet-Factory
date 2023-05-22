using System.Text;

namespace CarpetFactory;

class Vertex<T>
{

    List<Vertex<T>> neighbors;   
    T value;
    bool isVisited;

    public List<Vertex<T>> Neighbors { get { return neighbors; } set { neighbors = value; } }
    public T Value { get { return value; } set { this.value = value; } }
    public bool IsVisited { get { return isVisited; } set { isVisited = value; } }
    public int NeighborsCount { get { return neighbors.Count; } }

    public Vertex(T value)
    {
        this.value = value;
        isVisited = false;
        neighbors = new List<Vertex<T>>();
    }

    public Vertex(T value, List<Vertex<T>> neighbors)
    {
        this.value = value;
        isVisited = false;
        this.neighbors = neighbors;
    }

    public void Visit()
    {
        isVisited = true;
    }

    public void AddEdge(Vertex<T> vertex)
    {
        neighbors.Add(vertex);
    }

    public void AddEdges(List<Vertex<T>> newNeighbors)
    {
        neighbors.AddRange(newNeighbors);
    }

    public void RemoveEdge(Vertex<T> vertex)
    {
        neighbors.Remove(vertex);
    }


    public override string ToString()
    {

        StringBuilder allNeighbors = new StringBuilder("");
        allNeighbors.Append(value + ": ");

        foreach (Vertex<T> neighbor in neighbors)
        {
            allNeighbors.Append(neighbor.value + "  ");
        }

        return allNeighbors.ToString();

    }

}