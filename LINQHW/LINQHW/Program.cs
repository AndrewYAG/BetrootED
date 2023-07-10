using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;

namespace LINQHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = "D:\\GitHubRepos\\BetrootED\\LINQHW\\LINQHW\\data.json";

            StreamReader sr = new StreamReader(fileLocation);
            var persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd());
            sr.Close();

            // find out who is located farthest north/south/west/east using latitude/longitude data
            var eastmostPerson = persons.MaxBy(x => x.Longitude);
            var westernmostPerson = persons.MinBy(x => x.Longitude);
            var northernmostPerson = persons.MaxBy(x => x.Latitude);
            var southernmostPerson = persons.MinBy(x => x.Latitude);

            Console.WriteLine("Find out who is located farthest north/south/west/east:");
            Console.WriteLine($"Eastest (Longitude: {eastmostPerson.Longitude}) " +
                $"most person - Id:{eastmostPerson.Id}, Name:{eastmostPerson.Name}");
            Console.WriteLine($"Western (Longitude: {westernmostPerson.Longitude}) " +
                $"most person - Id:{westernmostPerson.Id}, Name:{westernmostPerson.Name}");
            Console.WriteLine($"Northern (Latitude: {northernmostPerson.Longitude}) " +
                $"most person - Id:{northernmostPerson.Id}, Name:{northernmostPerson.Name}");
            Console.WriteLine($"Southern (Latitude: {southernmostPerson.Longitude}) " +
                $"most person - Id:{southernmostPerson.Id}, Name:{southernmostPerson.Name}");

            // find max and min distance between 2 persons
            double maxDistance = persons.Max(p1 => persons.Max(p2 => CalculateDistance(p1, p2)));
            double minDistance = persons.Min(p1 => persons.Where(p2 => p1 != p2).Min(p2 => CalculateDistance(p1, p2)));

            Console.WriteLine($"\nMax distance berween two persons = {maxDistance}");
            Console.WriteLine($"Min distance berween two persons = {minDistance}");

            // find 2 persons whos ‘about’ have the most same words
            var personsWithMaxCommonWords = persons.SelectMany(p1 => persons.Where(p2 => p1 != p2)
                                               .Select(p2 => new
                                               {
                                                   FirstPerson = p1,
                                                   SecondPerson = p2,
                                                   CommonWords = CalculateAmountOfCommonWords(p1.About, p2.About)
                                               }))
                                        .OrderByDescending(pair => pair.CommonWords)
                                        .FirstOrDefault();

            Console.WriteLine("\nTwo persons whos ‘about’ have the most same words:");
            Console.WriteLine($"(Words: {personsWithMaxCommonWords.CommonWords}), " +
                $"Id:{personsWithMaxCommonWords.FirstPerson.Id}, Name: {personsWithMaxCommonWords.FirstPerson.Name}");
            Console.WriteLine($"(Words: {personsWithMaxCommonWords.CommonWords}), " +
                $"Id:{personsWithMaxCommonWords.SecondPerson.Id}, Name: { personsWithMaxCommonWords.SecondPerson.Name}");

            // find persons with same friends (compare by friend’s name)
            var personsWithSameFriends = persons
            .SelectMany(p => p.Friends.Select(f => new { Person = p, FriendName = f.Name }))
            .GroupBy(p => p.FriendName)
            .Where(g => g.Count() > 1);
            // don't work

        }

        public static int CalculateAmountOfCommonWords(string firstAbout, string secondAbout)
        {
            var stringDivisionSymbs = new char[] { ' ', '.', ',', ';', ':', '!', '?' };

            string[] firstAboutWords = firstAbout.Split(stringDivisionSymbs, StringSplitOptions.RemoveEmptyEntries);
            string[] secondAboutWords = secondAbout.Split(stringDivisionSymbs, StringSplitOptions.RemoveEmptyEntries);

            return firstAboutWords.Intersect(secondAboutWords, StringComparer.OrdinalIgnoreCase).Count();
        }

        public static double CalculateDistance(Person person1, Person person2)
        {
            const double earthRadius = 6371; // Радіус Землі в кілометрах

            double lat1 = ToRadians(person1.Latitude);
            double lon1 = ToRadians(person1.Longitude);
            double lat2 = ToRadians(person2.Latitude);
            double lon2 = ToRadians(person2.Longitude);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = earthRadius * c;
            return distance;
        }

        public static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}