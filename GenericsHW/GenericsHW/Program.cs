namespace GenericsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.Peek());

            Console.WriteLine(stack.Pop());

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);
        }
    }
}