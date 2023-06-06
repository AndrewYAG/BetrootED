namespace ConsoleApp1
{
    public class Car : Vehicle
    {
        protected Client Owner { get; set; }

        public Car(string brand, string model, int yearOfProduction, int id, Client owner) 
            : base(brand, model, yearOfProduction, id)
        {
            Owner = owner;
        }

        public Car(CarElement[] elemsUsedInRepairProcess, string brand, string model, int yearOfProduction, int id, Client owner)
            : base(elemsUsedInRepairProcess, brand, model, yearOfProduction, id)
        {
            Owner = owner;
            this._elemsUsedInRepairProcess = elemsUsedInRepairProcess;
        }

        public void SetOwner(in Client updatedOwner)
        {
            Owner = updatedOwner;
        }
       
        public override string ToString()
        {
            return $"Car id:{Id} info: {Brand} - {Model} Produced in {YearOfProduction} year. " +
                $"Owner is {Owner.FirstName} {Owner.LastName}, Contact: {Owner.PhoneNum}";
        }
    }
}