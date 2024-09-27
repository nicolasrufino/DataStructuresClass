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

// public class Node
// {
//     public int Data;
//     public Node Left;
//     public Node Right;

//     public Node(int data)
//     {
//         Data = data;
//     }
// }

// public class BestBinaryTree
// {
//     public Node Root;

//     public BestBinaryTree() { }

//     public BestBinaryTree(Node node)
//     {
//         Root = node;
//     }

//     public void InOrderTraversal(Node node)
//     {
//         if (node == null)
//         {
//             return;
//         }

//         InOrderTraversal(node.Left);
//         Console.WriteLine(node.Data + " ");
//         InOrderTraversal(node.Right);
//     }

//     public void DescendingTraversal(Node node)
//     {
//         if (node == null)
//         {
//             return;
//         }

//         DescendingTraversal(node.Right);
//         Console.WriteLine(node.Data + " ");
//         DescendingTraversal(node.Left);
//     }

// }

// class Program
// {
//     static void Main()
//     {
//         Console.Clear();
//         BestBinaryTree tree = new BestBinaryTree();

//         tree.Root = new Node(5);
//         tree.Root.Left = new Node(3);
//         tree.Root.Left.Left = new Node(2);
//         tree.Root.Left.Right = new Node(4);
//         tree.Root.Right = new Node(6);
//         tree.Root.Right.Right = new Node(8);
//         tree.Root.Right.Right.Left = new Node(7);
//         tree.Root.Right.Right.Right = new Node(9);

//         //tree.InOrderTraversal(tree.Root);
//         tree.DescendingTraversal(tree.Root);
//     }
// }

/*------------Friday, September 27th-------------*/

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
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

    public void ClearTree()
    {
        Root = null;
    }

    public int MinValue(Node currentNode)
    {
        while (currentNode.Left != null)
        {
            currentNode = currentNode.Left;
        }

        return currentNode.Data;
    }

    public int MaxValue(Node currentNode)
    {
        while (currentNode.Right != null)
        {
            currentNode = currentNode.Right;
        }

        return currentNode.Data;
    }

    public void InsertNode(int data)
    {
        Root = InsertNode(Root, data);
    }

    public Node InsertNode(Node curNode, int data)
    {
        Node node = new Node(data);

        if (curNode == null)
        {
            curNode = node;
            return curNode;
        }

        if (data < curNode.Data)
        {
            curNode.Left = InsertNode(curNode.Left, data);
        }
        else if (data > curNode.Data)
        {
            curNode.Right = InsertNode(curNode.Right, data);
        }

        return curNode;
    }

    public bool FindNode(int target)
    {
        return FindNode(Root, target);
    }

    public bool FindNode(Node currentNode, int target)
    {
        if (currentNode == null)
        {
            Console.WriteLine($"{target} not found");
            return false;
        }
        if (currentNode.Data == target)
        {
            Console.WriteLine($"{target} was found!! Huzzah!!!");
            return true;
        }

        if (target < currentNode.Data)
        {
            return FindNode(currentNode.Left, target);
        }

        return FindNode(currentNode.Right, target);

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
    }

    public void DescendingTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }

        DescendingTraversal(node.Right);
        Console.WriteLine(node.Data + " ");
        DescendingTraversal(node.Left);
    }

}

class Program
{
    static void Main()
    {
        BestBinaryTree tree = new BestBinaryTree();

        tree.InsertNode(5);
        tree.InsertNode(3);
        tree.InsertNode(2);
        tree.InsertNode(4);
        tree.InsertNode(6);
        tree.InsertNode(8);
        tree.InsertNode(7);
        tree.InsertNode(9);

        Console.WriteLine("Found:" + tree.FindNode(10));
        Console.WriteLine("Found:" + tree.FindNode(7));
        //tree.Root = new Node(5);
        //tree.Root.Left = new Node(3);
        //tree.Root.Left.Left = new Node(2);
        //tree.Root.Left.Right = new Node(4);
        //tree.Root.Right = new Node(6);
        //tree.Root.Right.Right = new Node(8);
        //tree.Root.Right.Right.Left = new Node(7);
        //tree.Root.Right.Right.Right = new Node(9);

        tree.InOrderTraversal(tree.Root);
        //tree.DescendingTraversal(tree.Root);
    }
}