using System.Net;
using System.Threading.Tasks;

namespace AsyncHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string randomApi = "https://randomuser.me/api/";

            var request = Task.Run(() => DownloadUrl(randomApi));

            var result = request.Result;
            result.EnsureSuccessStatusCode();

            var stringResult = result.Content.ReadAsStringAsync().Result;

            PrintRandomUser(stringResult);
        }
        public static async Task<HttpResponseMessage> DownloadUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetAsync(url);
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
        }
        public static void PrintRandomUser(string data)
        {
            dynamic userObject = Newtonsoft.Json.JsonConvert.DeserializeObject(data);

            string firstName = userObject.results[0].name.first;
            string lastName = userObject.results[0].name.last;
            string email = userObject.results[0].email;
            string gender = userObject.results[0].gender;
            string city = userObject.results[0].location.city;
            string country = userObject.results[0].location.country;
            string phone = userObject.results[0].phone;

            Console.WriteLine("Random User Information:");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Location: {city}, {country}");
            Console.WriteLine($"Phone: {phone}");
        }
    }
}