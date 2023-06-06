namespace ConsoleApp1
{
    public class Client : Person
    {
        protected Vehicle[] _ownedVehicle = new Vehicle[0];
        public int DebtinDollars { get; set; }

        public Client(string firstName, string lastName, DateTime birtDate, string address, string phoneNum)
            : base(firstName, lastName, birtDate, address, phoneNum)
        {
        }

        public Client(string firstName, string lastName, DateTime birtDate, string address, string phoneNum, Vehicle[] ownedVehicle)
            : base(firstName, lastName, birtDate, address, phoneNum)
        {
            _ownedVehicle = ownedVehicle;
        }

        public void AddOwnedVehicle(Car car)
        {
            Array.Resize(ref _ownedVehicle, _ownedVehicle.Length + 1);
            _ownedVehicle[_ownedVehicle.Length - 1] = car;
        }
        public void ShowOwnedVehicle()
        {
            foreach(var car in _ownedVehicle)
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