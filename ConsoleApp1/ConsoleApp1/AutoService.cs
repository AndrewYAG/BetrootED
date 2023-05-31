namespace ConsoleApp1
{
    public class AutoService : OflineService
    {
        protected Client[] clients = new Client[0];
        protected CarElement[] carElementsInStock = new CarElement[0];

        public void AddCarElementsInStock(CarElement elem)
        {
            Array.Resize(ref carElementsInStock, carElementsInStock.Length + 1);
            carElementsInStock[carElementsInStock.Length - 1] = elem;
        }
        public void ShowCarElementsInStock()
        {
            foreach (var elem in carElementsInStock)
            {
                Console.WriteLine(elem);
            }
        }

        public void AddClients(Client newClient)
        {
            Array.Resize(ref clients, clients.Length + 1);
            clients[clients.Length - 1] = newClient;
        }
        public void ShowAllClients()
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }
    }
}