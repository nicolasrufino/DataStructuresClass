using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class StackNode<T>
{
    public T Data { get; set; }
    public StackNode<T> Next { get; set; }

    public StackNode(T data)
    {
        Data = data;
        Next = null;
    }
}
class CustomStack<T>
{
    private StackNode<T> top;

    public void Push(T data)
    {
        StackNode<T> newNode = new StackNode<T>(data);
        newNode.Next = top;
        top = newNode;
    }

    public T Pop()
    {
        if (top == null)
        {
            Console.WriteLine("It's empty!");
        }

        T item = top.Data;
        top = top.Next;
        return item;
    }

    public T Peek()
    {
        if (top == null)
        {
            Console.WriteLine("It's empty");
        }

        return top.Data;
    }

    public bool isEmpty()
    {
        return top == null;

    }
    public void Clear()
    {
        top = null;
    }
}

class Browser
{
    private CustomStack<string> backStack = new CustomStack<string>();
    private CustomStack<string> forwardStack = new CustomStack<string>();
    private string currentPage = "Home";

    public void visitPage(string url)
    {
        if (currentPage != null)
        {
            backStack.Push(currentPage);
        }
        currentPage = url;
        forwardStack = new CustomStack<string>();
        DisplayCurrentPage();
    }
    public void goBack()

    {
        if (!backStack.isEmpty())
        {
            forwardStack.Push(currentPage);
            currentPage = backStack.Pop();
            DisplayCurrentPage();
        }
        else
        {
            Console.WriteLine("There's nothing to go back to.");
        }
    }
    public void goFoward()
    {
        if (!forwardStack.isEmpty())
        {
            backStack.Push(currentPage);
            currentPage = forwardStack.Pop();
            DisplayCurrentPage();
        }
        else
        {
            Console.WriteLine("There is nothing to go forward to.");
        }
    }
    public void DisplayCurrentPage()
    {
        Console.WriteLine("Current Page is " + currentPage);
    }


}

namespace Whatever
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Stack<int> stack = new Stack<int>();
            //the one below is our costumStack
            // CustomStack<int> stack = new CustomStack<int>(); 
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Peek " + stack.Peek());
            Console.WriteLine("Peek " + stack.Pop());
            Console.WriteLine("Peek " + stack.Pop());
            Console.WriteLine("Peek " + stack.Pop());

            Browser browser = new Browser();
            browser.visitPage("https://appodroid.com");
            browser.visitPage("https://RunakCore.com");
            browser.goBack();
            browser.goFoward();
        }
    }
}