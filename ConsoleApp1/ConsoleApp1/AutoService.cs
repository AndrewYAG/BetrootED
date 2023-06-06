namespace ConsoleApp1
{
    public class AutoService : OflineService
    {
        protected Client[] _clients = new Client[0];
        protected CarElement[] _carElementsInStock = new CarElement[0];

        public AutoService(string title, string address, string contactNum) : base(title, address, contactNum)
        {
        }

        public AutoService(Employee[] employees, Client[] clients, CarElement[] carElementsInStock, string title,
            string address, string contactNum)
            : base(employees, title, address, contactNum)
        {
            _clients = clients;
            _carElementsInStock = carElementsInStock;
        }

        public void AddCarElementsInStock(CarElement elem)
        {
            Array.Resize(ref _carElementsInStock, _carElementsInStock.Length + 1);
            _carElementsInStock[_carElementsInStock.Length - 1] = elem;
        }
        public void ShowCarElementsInStock()
        {
            foreach (var elem in _carElementsInStock)
            {
                Console.WriteLine(elem);
            }
        }

        public void AddClients(Client newClient)
        {
            Array.Resize(ref _clients, _clients.Length + 1);
            _clients[_clients.Length - 1] = newClient;
        }
        public void ShowAllClients()
        {
            foreach (var client in _clients)
            {
                Console.WriteLine(client);
            }
        }
    }
}