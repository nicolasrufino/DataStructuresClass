public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public int Strength { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int id, string name, string type, string rarity, int strength)
    {
        Id = id;
        Name = name;
        Type = type;
        Rarity = rarity;
        Strength = strength;
        Left = null;
        Right = null;
    }
}

public class BinaryTree
{
    public Node Root;

    public BinaryTree() { }

    public BinaryTree(Node node)
    {
        Root = node;
    }

    
 
}