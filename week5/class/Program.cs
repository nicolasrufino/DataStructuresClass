// Queue<Customer> Testing = new Queue<int>();

// Testing

// public class Customer
// {
//     public string Name { get; set; }
//     public int NumberOfItems { get; set; }
//     public int TimePerItem { get; set; }

//     public Customer(string name, int numberOfItems, int timePerItem)
//     {
//         Name = name;
//         NumberOfItems = numberOfItems;
//         TimePerItem = timePerItem;
//     }

//     public int GetCheckOutTime()
//     {
//         return NumberOfItems = TimePerItem;
//     }
// }

//////////////////////////////////////////////////////////////////////////////////////


// public class TreeNode
// {
//     public int Value { get; set; }
//     public TreeNode Left { get; set; }
//     public TreeNode Right { get; set; }

//     public TreeNode(int value)
//     {
//         Value = value;
//         Left = null;
//         Right = null;
//     }

// }

/* --------------- Wednesday, September 25th ---------------*/

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
        // Left = null;
        // Right = null;
    }
}

public class BestBinaryTree
{
    public Node Root;

    public BestBinaryTree() { }

    public BestBinaryTree(Node node)
    {
        Root = node;
    }

    public void InOrderTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left);
        Console.WriteLine(node.Data + " ");
        InOrderTraversal(node.Right);
        Console.WriteLine(node.Data + " ");

    }
}

class Program
{
    static void Main()
    {
        BestBinaryTree tree = new BestBinaryTree();

        tree.Root = new Node(5);
        tree.Root.Left = new Node(3);
        tree.Root.Left.Left = new Node(2);
        tree.Root.Left.Right = new Node(4);

        tree.Root.Right = new Node(8);
        tree.Root.Right.Left = new Node(7);
        tree.Root.Right.Right = new Node(9);

        tree.InOrderTraversal(tree.Root);
    }
}