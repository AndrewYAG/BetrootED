namespace ConsoleApp1
{
    public class Client : Person
    {
        protected Vehicle[] ownedVehicle = new Vehicle[0];
        public int DebtinDollars { get; set; }

        public void AddOwnedVehicle(Car car)
        {
            Array.Resize(ref ownedVehicle, ownedVehicle.Length + 1);
            ownedVehicle[ownedVehicle.Length - 1] = car;
        }
        public void ShowOwnedVehicle()
        {
            foreach(var car in ownedVehicle)
            {
                Console.WriteLine(car);
            }
        }

        public override string ToString()
        {
            return $"Client: {FirstName} {LastName}, Address: {Address} with contact: {PhoneNum}";
        }
    }
}