string filePath = @"C:\Users\jidapa.angsutti\coding\CS2420-notes\nov-6\data.txt"; // change this

List<string> list = new(File.ReadAllLines(filePath));

Graph graph = new();

graph.AddEdge("A", "B", 4);
graph.AddEdge("A", "C", 2);
graph.AddEdge("B", "C", 5);
graph.AddEdge("B", "D", 10);

class Graph
{
    public Dictionary<string, List<Edge>> AdjacencyList { get; set; }
    public Graph()
    {
        AdjacencyList = new Dictionary<string, List<Edge>>();
    }
    public void AddEdge(string source, string destination, int weight = 1)
    {
        if (!AdjacencyList.ContainsKey(source))
        {
            AdjacencyList[source] = new List<Edge>();
        }
        AdjacencyList[source].Add(new Edge(destination, weight));
    }
    public void Display()
    {
        foreach (var edge in AdjacencyList)
        {
            Console.WriteLine(edge.Key + "->");
            //finish this one
            
        }
    }
}
public class Edge
{
    public string Destination { get; set; }
    public int Weight { get; set; }
    public Edge(string destination, int weight)
    {
        Destination = destination; Weight = weight;
    }
}