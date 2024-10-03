using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
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


    public int CalculateTheHeight(Node node)
    {
        if (node == null)
        {
            return -1;
        }
        int LeftNodeCount = CalculateTheHeight(node.Left);
        int RightNodeCount = CalculateTheHeight(node.Right);

        return Math.Max(LeftNodeCount, RightNodeCount) + 1;
    }
    public int calculateTheHeight()
    {
        return CalculateTheHeight(Root);
    }

    public bool IsBalanced()
    {
        if (Root == null)
        {
            return true;
        }

        int LeftNodeCount = CalculateTheHeight(Root.Left);
        int RightNodeCount = CalculateTheHeight(Root.Right);

        int heightDifference = Math.Abs(LeftNodeCount - RightNodeCount);

        if (heightDifference > 1)
        {
            return false;
        }

        return true;
    }
}