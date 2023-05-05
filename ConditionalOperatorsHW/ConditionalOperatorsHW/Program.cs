using System.Runtime.CompilerServices;

namespace ConditionalOperatorsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter X value: ");
            bool isValidX = int.TryParse(Console.ReadLine(), out int X);

            Console.Write("Enter Y value: ");
            bool isValidY = int.TryParse(Console.ReadLine(), out int Y);

            if(isValidX && isValidY)
                Console.WriteLine($"Your X = {X}, Y = {Y}");
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int Sum = 0;

            for (int i = Math.Min(X, Y); i <= Math.Max(X, Y); i++)
            {
                Sum += i;
            }

            Console.WriteLine("Sum = " + Sum);
        }
    }
}