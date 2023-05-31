namespace ConsoleApp1
{
    public class Engine : CarElement
    {
        public string Model { get; set; }
        public float Size { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nThe Engine Model is {Model}, Size: {Size}";
        }
    }
}