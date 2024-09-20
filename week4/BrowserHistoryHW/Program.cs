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
}

namespace Whatever
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            //the one below is our costumStack
            // CustomStack<int> stack = new CustomStack<int>(); 
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Peek "+ stack.Peek());
            Console.WriteLine("Peek "+ stack.Pop());
            Console.WriteLine("Peek "+ stack.Pop());
            Console.WriteLine("Peek "+ stack.Pop());

        }
    }
}