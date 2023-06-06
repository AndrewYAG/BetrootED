namespace ConsoleApp1
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Position { get; set; }
        protected Employee Chief { get; set; }

        public Employee(string firstName, string lastName, DateTime birtDate, string address, string phoneNum, int salary,
            string position, Employee chief)
            : base(firstName, lastName, birtDate, address, phoneNum)
        {
            this.Salary = salary;
            this.Position = position;
            this.Chief = chief;
        }

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