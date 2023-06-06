using System.Diagnostics;
using System.Reflection;

namespace AbstractAndInterfacesHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InternetShop newShop = new InternetShop("OnlineQ", "+380412521523", "OnlineQ.Com", ".com");

            newShop.RegisterNewProduct(
                new Phone("Samsung Galaxy S3", "Samsung", 300, "NEWNEWPHONE",
                "Phones", 43, 12, "S3", 6.23, 4, 128, "Android", 5000,
                "IPS", "Red")
                );

            newShop.RegisterNewClient(
                new Client("Andrew", "Hotson", new DateTime(2001, 12, 07), "Rivne, Independency st. 16B", "+38424129051",
                "andrewhotsot@gmail.com", new BankCard("4325125235315", "09/25", 623), 15)
                );

            newShop.SellProductByID(12, 15, 4);

            newShop.PrintClientsInfo();
        }
    }
}