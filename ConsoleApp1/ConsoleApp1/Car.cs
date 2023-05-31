namespace ConsoleApp1
{
    public class Car : Vehicle
    {
        protected Client Owner { get; set; }

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