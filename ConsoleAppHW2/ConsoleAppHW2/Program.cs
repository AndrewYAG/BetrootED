namespace ConsoleAppHW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // simple + & * example
            Console.WriteLine("Example of the result of addition, multiplication of int and double.\n");
            int a = 24, b = 40;
            Console.WriteLine("INT:\na + b = " + (a + b));
            Console.WriteLine("a * b = " + (a * b));

            double c = 24.452, d = 40.312;
            Console.WriteLine("\nDOUBLE:\nd + c = " + (d + c));
            Console.WriteLine("d * c = " + (d * c));

            // math functions example usage:
            //
            //max(x, y)

            Console.Write("\nEntre first num for the following calculations :> ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Entre second num for the following calculations :> ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine("\n-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15 = " + 
                (-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15));

            Console.WriteLine("abs(x) * sin(x) = " + (Math.Abs(x) * Math.Sin(x)));

            Console.WriteLine("2 * pi * x = " + (2 * Math.PI * x));

            Console.WriteLine("max(x, y) = " + Math.Max(x, y));

            // Write to console how many days left to New Year and how many days passed from New Year.
            // Result in console should look like this:
            // X days left to New Year, Y days passed from New Year.

            DateTime now = DateTime.Now;
            DateTime PreviousNewYear = new DateTime((now.Year - 1), 12, 31);
            DateTime NextNewYear = new DateTime(now.Year, 12, 31);

            Console.WriteLine($"\n\n{(NextNewYear - now).TotalDays:f1} left to New Year," +
                $" {(now - PreviousNewYear).TotalDays:f1} days passed from New Year.");
        }
    }
}