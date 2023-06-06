namespace AbstractAndInterfacesHW
{
    public class Product : IRenewableAndSellable
    {
        public string Title { get; private set; }
        public string Producer { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public int QuantityInStock { get; private set; }
        public int ProductID { get; init; }
        public string Model { get; private set; }

        public Product(string title, string producer, int price, string description, string category, int quantityInStock,
            int productID, string model)
        {
            Title = title;
            Producer = producer;
            Price = price;
            Description = description;
            Category = category;
            QuantityInStock = quantityInStock;
            ProductID = productID;
            Model = model;
        }

        public void SellProductFromStock(int amountToSell)
        {
            if (QuantityInStock - amountToSell < 0)
                throw new Exception($"Error! Not enought product units in stock! You tried to sell {amountToSell} units, when" +
                    $" there are only {QuantityInStock} items left in stock.");

            QuantityInStock -= amountToSell;
        }

        public void RenewProductAmountInStock(int amountToRenew)
        {
            this.QuantityInStock += amountToRenew;
        }

        public override string ToString()
        {
            return $"Product: {Title} from {Category} category.\nProducer:{Producer}, model:{Model}, price: {Price}";
        }
    }
}