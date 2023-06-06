namespace AbstractAndInterfacesHW
{
    public class Shop : IProductable, IClientable
    {
        protected Employee[] _listOfEmployees = new Employee[0];
        protected Product[] _products = new Product[0];
        protected Client[] _listOfClients = new Client[0];

        public string Title { get; set; }
        public string PhoneNumber { get; set; }


        public Shop(Employee[] listOfEmployees, Product[] products, Client[] listOfClients, string title, string phoneNumber)
        {
            _listOfEmployees = listOfEmployees;
            _products = products;
            _listOfClients = listOfClients;
            Title = title;
            PhoneNumber = phoneNumber;
        }

        public Shop(string title, string phoneNumber)
        {
            Title = title;
            PhoneNumber = phoneNumber;
        }

        public void RegisterNewProduct(Product newProductToRegister)
        {
            Array.Resize(ref _products, _products.Length + 1);
            _products[^1] = newProductToRegister;
        }

        public void SellProductByID(int productIDToSell, int clientIDToSellTo, int amountToSell)
        {
            bool wasClientFoundFlag = false;

            Product[] soldProducts = new Product[0];

            for (int i = 0; i < _products.Length; i++)
            {
                if (productIDToSell == _products[i].ProductID)
                {
                    _products[i].SellProductFromStock(amountToSell);
                    Product productToSell = _products[i];
                    for (int j = 0; j < amountToSell; j++)
                    {
                        Array.Resize(ref soldProducts, soldProducts.Length + 1);
                        soldProducts[j] = productToSell;
                    }

                    break;
                }
            }


            if (soldProducts.Length == 0)
                throw new Exception($"Error! Product to sell wasn't found, id of the product:{productIDToSell}.");


            for (int i = 0; i < _listOfClients.Length; i++)
            {
                if (clientIDToSellTo == _listOfClients[i].ID)
                {
                    _listOfClients[i].AddNewReceipt(
                        new Receipt(Guid.NewGuid().ToString(), _listOfClients[i], DateTime.Now,
                        soldProducts, _listOfClients[i].Address, 65, _listOfClients[i].DefaultPaymentCard)
                            );

                    _listOfClients[i].AddProductToPurchased(soldProducts);
                    wasClientFoundFlag = true;
                    break;
                }
            }

            if (!wasClientFoundFlag)
                throw new Exception($"Error! Client to sell to wasn't found, id of the client:{clientIDToSellTo}.");
        }

        public void RegisterNewClient(Client newClientToRegister)
        {
            Array.Resize(ref _listOfClients, _listOfClients.Length + 1);
            _listOfClients[^1] = newClientToRegister;
        }

        public void RegisterNewEmployee(Employee newEmployee)
        {
            Array.Resize(ref _listOfEmployees, _listOfEmployees.Length + 1);
            _listOfEmployees[^1] = newEmployee;
        }

        public void PrintClientsInfo()
        {
            Console.WriteLine("PRINTING ALL CLIENTS INFO....\n");

            foreach (var item in _listOfClients)
            {
                Console.WriteLine(item);

                Console.WriteLine("LISTO OF PURCHASED PRODUCTS:\n");
                item.PrintPurchasedProducts();

                Console.WriteLine("LIST OF RECEIPTS:\n");
                item.PrintReceipts();
            }

            Console.WriteLine("PRINTING FINISHED...");
        }
    }
}