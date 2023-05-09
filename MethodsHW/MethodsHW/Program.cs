namespace MethodsHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
      /*      // Define and call with different parameters next methods:

            Console.Write("Enter first num:");
            int firstNum = int.Parse(Console.ReadLine());

            Console.Write("Enter second num:");
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nMax = {GetMax(firstNum, secondNum)}, Min = {GetMin(firstNum, secondNum)}");

            // 3. Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs
            //is odd, otherwise false, sum return as out parameter
            bool TrySumIfOdd(int num1, int num2, out int sumBetweenInputs)
            {
                sumBetweenInputs = 0;
                int startNum = GetMin(num1, num2);
                int endNum = GetMax(num1, num2);

                for (int i = startNum; i <= endNum; i++)
                {
                    sumBetweenInputs += i;
                }

                return sumBetweenInputs % 2 != 0;
            }

            Console.WriteLine($"\nNum1 = {firstNum}, Num2 = {secondNum}, " +
                $"sum between inputs is odd: {TrySumIfOdd(firstNum, secondNum, out int resultSum)}" +
                $", Sum = {resultSum}");

            // Define and call with different parameters next methods:
            // Method Repeat that will accept string X and number N and
            // return X repeated N times (e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)
            string Repeat(string X, int N)
            {
                string resultingString = string.Empty;
                for (int i = 0; i < N; i++)
                {
                    resultingString += X;
                }
                return resultingString;
            }

            int numToRepeat = 4;
            string testString = "I love u!";

            Console.WriteLine($"\nOriginal string: {testString}.\n" +
                $"String repeated {numToRepeat} times: {Repeat(testString, numToRepeat)}");

            numToRepeat = 2;
            testString = "string!";

            Console.WriteLine($"\nOriginal string: {testString}.\n" +
                $"String repeated {numToRepeat} times: {Repeat(testString, numToRepeat)}");*/

            // recursion with Fibonacci sequance 
            int GetFiboElement(int position) // 0, 1, 1, 2, 3, 5, 8, 13, 21...
            {
                if(position <= 1) return 0;
                if(position == 2) return 1;
                return GetFiboElement(position - 1) + GetFiboElement(position - 2);
            }

            int GetFiboSeqSum(int count)
            {
                /*int sum = 0;
                for (int i = 1; i <= count; i++)
                {
                    sum += GetFiboElement(i);
                }*/
                if(count <= 1) return 0;
                if (count == 2) return 1;
                return GetFiboElement(count) + GetFiboSeqSum(count - 1);
            }
            Console.WriteLine(GetFiboElement(7));;
            Console.WriteLine(GetFiboSeqSum(7));
        }
        // 1. Method that will return max value among all the parameters
        // 2. … min value …
        private static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        private static int GetMin(int a, int b)
        {
            return a < b ? a : b;
        }

        // 4. Overload first two methods with 3 and 4 parameters
        private static int GetMax(int a, int b, int c)
        {
            return Math.Max(Math.Max(a, b), c);
        }

        private static int GetMin(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
        private static int GetMax(int a, int b, int c, int d)
        {
            return Math.Max(Math.Max(a, b), Math.Max(c, d));
        }

        private static int GetMin(int a, int b, int c, int d)
        {
            return Math.Min(Math.Min(a, b), Math.Min(c, d));
        }
    }
}