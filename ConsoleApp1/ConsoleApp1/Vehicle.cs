namespace ConsoleApp1
{
    public class Vehicle
    {
        protected CarElement[] _elemsUsedInRepairProcess = new CarElement[0];
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int Id { get; set; }

        public Vehicle(string brand, string model, int yearOfProduction, int id)
        {
            Brand = brand;
            Model = model;
            YearOfProduction = yearOfProduction;
            Id = id;
        }

        public Vehicle(CarElement[] elemsUsedInRepairProcess, string brand, string model, int yearOfProduction, int id)
            : this(brand, model, yearOfProduction, id)
        {
            _elemsUsedInRepairProcess = elemsUsedInRepairProcess;
        }

        public void AddElemsUsedInRepair(CarElement newElem)
        {
            Array.Resize(ref _elemsUsedInRepairProcess, _elemsUsedInRepairProcess.Length + 1);
            _elemsUsedInRepairProcess[_elemsUsedInRepairProcess.Length - 1] = newElem;
        }
        public void ShowElemsUsedInRepair()
        {
            foreach (var elem in _elemsUsedInRepairProcess)
            {
                Console.WriteLine(elem);
            }
        }
    }
}