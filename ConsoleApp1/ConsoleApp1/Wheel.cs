namespace ConsoleApp1
{
    public class Wheel : CarElement
    {
        public string Pattern { get; set; }
        public bool IsSummerType { get; set; }
        public bool IsWinerType { get; set; }

        public override string ToString()
        {
            string usagePeriodOfWheel = IsSummerType == true ? "Summer" : "Winter";
            return base.ToString() + $"\nThe Wheel has {Pattern} patern and is used in {usagePeriodOfWheel}";
        }
    }
}