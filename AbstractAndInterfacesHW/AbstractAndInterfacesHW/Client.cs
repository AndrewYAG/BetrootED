namespace AbstractAndInterfacesHW
{
    public class Client : Person
    {
        private Product[] _basketOfProductsToBuy = new Product[0];
        private Product[] _listOfPurchasedProducts = new Product[0];
        private Receipt[] _listOfReceipts = new Receipt[0];
        public BankCard DefaultPaymentCard { get; set; }
        public int ID { get; init; }

        public Client(string firstName, string lastName, DateTime birthDate, string address, string phoneNum, string email,
            BankCard defaultPaymentCard, int id)
            : base(firstName, lastName, birthDate, address, phoneNum, email)
        {
            DefaultPaymentCard = defaultPaymentCard;
            ID = id;
        }

        public Client(string firstName, string lastName, DateTime birthDate, string address, string phoneNum, string email,
            Product[] basketOfProductsToBuy, Product[] listOfPurchasedProducts, BankCard defaultPaymentCard,
            Receipt[] listOfReceipts, int id)
            : base(firstName, lastName, birthDate, address, phoneNum, email)
        {
            _basketOfProductsToBuy = basketOfProductsToBuy;
            _listOfPurchasedProducts = listOfPurchasedProducts;
            DefaultPaymentCard = defaultPaymentCard;
            _listOfReceipts = listOfReceipts;
            ID = id;
        }

        public void AddProductToPurchased(params Product[] newPurchasedProducts)
        {
            int oldLength = _listOfPurchasedProducts.Length;
            Array.Resize(ref _listOfPurchasedProducts, _listOfPurchasedProducts.Length + newPurchasedProducts.Length);
            Array.Copy(newPurchasedProducts, 0, _listOfPurchasedProducts, oldLength, newPurchasedProducts.Length);
        }

        public void AddNewReceipt(Receipt newReceipt)
        {
            Array.Resize(ref _listOfReceipts, _listOfReceipts.Length + 1);
            _listOfReceipts[^1] = newReceipt;
        }

        public void PrintPurchasedProducts()
        {
            foreach (var item in _listOfPurchasedProducts)
            {
                Console.WriteLine(item + "\n");
            }
        }

        public void PrintReceipts()
        {
            foreach (var item in _listOfReceipts)
            {
                Console.WriteLine(item + "\n");
            }
        }

        public override string ToString()
        {
            return $"Client: {FirstName} {LastName}, Phone:{PhoneNum}, Address:{Address}, Birth Date:{BirthDate}.";
        }
    }
}