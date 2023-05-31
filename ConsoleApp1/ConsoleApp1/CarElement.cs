namespace ConsoleApp1
{
    public class CarElement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }

        public override string ToString()
        {
            return $"This is {this.GetType}. Name: {Name}, Price: {Price}$, Amount in stock is: {AmountInStock}." +
                $"\nDescription: {Description}";
        }
    }
}