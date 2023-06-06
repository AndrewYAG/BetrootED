namespace AbstractAndInterfacesHW
{
    public class InternetShop : Shop
    {
        public string URL { get; set; }
        public string Domain { get; set; }

        public InternetShop(string title, string phoneNumber, string url, string domain) : base(title, phoneNumber)
        {
            URL = url;
            Domain = domain;
        }

        public InternetShop(Employee[] listOfEmployees, Product[] products, Client[] listOfClients, string title, string phoneNumber,
            string url, string domain)
            : base(listOfEmployees, products, listOfClients, title, phoneNumber)
        {
            URL = url;
            Domain = domain;
        }
    }
}