using System.Reflection;

namespace RefloctionHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = "OOPIncapsulationHW.dll";

            PrintAssemblyInfoToConsole(assemblyPath);
        }

        public static void PrintAssemblyInfoToConsole(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.WriteLine($"Classes and methods of assebly: \n{assembly.FullName} \nfrom path: {assemblyPath}.");

            Type[] types = assembly.GetTypes();

            foreach (var type in types)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nClass {type.Name}");

                foreach (var method in type.GetMethods())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Method {method.Name} with {method.ReturnType.Name}-return type");

                    foreach (var argumentOfMethod in method.GetParameters())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Argument: {argumentOfMethod.Name} of {argumentOfMethod.ParameterType.Name}-type");
                    }
                }
            }
            Console.ResetColor();
        }
    }
}