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
    public int calculateTheHeight(Node node)
    {
        if (node == null)
        {
            return -1;
        }
        int LeftNodeCount = calculateTheHeight(node.Left);
        int RightNodeCount = calculateTheHeight(node.Right);

        return Math.Max(LeftNodeCount, RightNodeCount) + 1;
    }

    public bool isBalanced(Node node)
    {
        if (node == null)
        {
            return true;
        }

        int LeftNodeCount = calculateTheHeight(node.Left);
        int RightNodeCount = calculateTheHeight(node.Right);

        int heightDifference = Math.Abs(LeftNodeCount - RightNodeCount);

        if (heightDifference > 1)
        {
            return false;
        }

        return isBalanced(node.Left) && isBalanced(node.Right);
    }
}