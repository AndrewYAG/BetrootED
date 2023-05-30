using static System.Reflection.Metadata.BlobBuilder;

namespace ClassIntroHW
{
    public class Book
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int NumOfCopies { get; set; }
        public int ID { get; set; }
        public Client[] takenByClients = new Client[0];

        public void GiveClientBook(Client client)
        {
            Array.Resize<Client>(ref takenByClients, takenByClients.Length + 1);
            takenByClients[^1] = client;
        }
        public bool IsAvailableToTake()
        {
            return NumOfCopies - takenByClients.Length > 0 ? true : false;
        }
        public void ShowTakenBy()
        {
            foreach (Client client in takenByClients)
            {
                Console.WriteLine(client);
            }
        }
        public override string ToString()
        {
            return $"ID: {ID} -- {Title}, {Author}, Year: {Year}, Publisher: {Publisher}";
        }
    }
}