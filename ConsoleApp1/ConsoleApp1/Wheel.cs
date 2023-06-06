using System.Drawing;
using System.Reflection;

namespace ConsoleApp1
{
    public class Wheel : CarElement
    {
        public string Pattern { get; set; }
        public bool IsSummerType { get; set; }
        public bool IsWinerType { get; set; }

        public Wheel(string name, string description, decimal price, int amountInStock, string pattern, bool isSummerType, bool isWinerType)
            : base(name, description, price, amountInStock)
        {
            if (isSummerType == isWinerType)
                throw new Exception($"Error! Wheel is either summer and winter type or neither ({isWinerType} in both cases)" +
                    $" at the same time!");

            Pattern = pattern;
            IsSummerType = isSummerType;
            IsWinerType = isWinerType;
        }

        public override string ToString()
        {
            string usagePeriodOfWheel = IsSummerType == true ? "Summer" : "Winter";
            return base.ToString() + $"\nThe Wheel has {Pattern} patern and is used in {usagePeriodOfWheel}";
        }
    }
}