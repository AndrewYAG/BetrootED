namespace ConsoleApp1
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Position { get; set; }
        protected Employee Chief { get; set; }
        public void SetChief(Employee newChief)
        {
            Chief = newChief;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} - Position: {Position} with salary: {Salary}";
        }
    }
}