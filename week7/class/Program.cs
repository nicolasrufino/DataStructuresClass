using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Data { get; set; }
    public Node(int value, int data)
    {
        Value = value;
        Data = data;
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
        Node node = new Node(data, data);

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
    /* Pseudo Code to get the tree rotation method:

    for tree rotation we need to check if its balanced or not
    while loop to check if its balanced 
    if not we re-do the balance
    we have to check which way to rotate
    keep track of the long, in this case lefts, side's child
   for this case, set the roots child to now be the childs right child
    */
    public void TreeBalancer()
    {
        bool keepBalancing = !IsBalanced();
        while (keepBalancing)
        {
            //which side is the tall side, which way to rotate?
            int LeftNodeCount = CalculateTheHeight(Root.Left);
            int RightNodeCount = CalculateTheHeight(Root.Right);

            //right rotation
            Node B = Root.Left;
            Node A = Root;
            Node E = Root.Left.Right;

            Root = B;
            B.Right = A;
            A.Left = E;

            //keep track of lefts sides child
            //set the roots left child to now be the childs right

            if (IsBalanced())
            {
                keepBalancing = false;
            }
        }
    }

    public Node Delete(int key)
    {
        return Delete(Root, key);
    }

    public Node Delete(Node currentNode, int key)
    {
        if (currentNode == null)
        {
            return currentNode;
        }
        if (key < currentNode.Data)
        {
            currentNode.Left = Delete(currentNode.Left, key);
        }
        else if (key > currentNode.Data)
        {
            currentNode.Right = Delete(currentNode.Right, key);
        }
        else
        {
            //Node with one child or more
            if (currentNode.Left == null)
            {
                return currentNode.Right;
            }
            else if (currentNode.Right == null)
            {
                return currentNode.Left;
            }

            currentNode.Data = MinValue(currentNode.Right);
            currentNode.Right = Delete(currentNode.Right, currentNode.Data);
        }
        return currentNode;
    }
}

public class Program
{
    public void Main()
    {

    }
}