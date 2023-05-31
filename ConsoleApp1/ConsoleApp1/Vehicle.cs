namespace ConsoleApp1
{
    public class Vehicle
    {
        protected CarElement[] elemsUsedInRepairProcess = new CarElement[0];
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int Id { get; set; }

        public void AddElemsUsedInRepair(CarElement newElem)
        {
            Array.Resize(ref elemsUsedInRepairProcess, elemsUsedInRepairProcess.Length + 1);
            elemsUsedInRepairProcess[elemsUsedInRepairProcess.Length - 1] = newElem;
        }
        public void ShowElemsUsedInRepair()
        {
            foreach (var elem in elemsUsedInRepairProcess)
            {
                Console.WriteLine(elem);
            }
        }
    }
}