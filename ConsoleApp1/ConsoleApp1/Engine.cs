namespace ConsoleApp1
{
    public class Engine : CarElement
    {
        public string Model { get; set; }
        public double Size { get; set; }

        public Engine(string name, string description, decimal price, int amountInStock, string model, double size)
            : base(name, description, price, amountInStock)
        {
            Model = model;
            Size = size;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nThe Engine Model is {Model}, Size: {Size}";
        }
    }
}