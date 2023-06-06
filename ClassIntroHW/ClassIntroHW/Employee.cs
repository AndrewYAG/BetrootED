namespace ClassIntroHW
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Position { get; set; }
        public Employee Chief { get; set; }

        public Employee(string firstName, string lastName, int age, DateTime birthDate, string address, string phoneNum,
            int salary, string position, Employee chief) : base(firstName, lastName, age, birthDate, address, phoneNum)
        {
            Salary = salary;
            Position = position;
            Chief = chief;
        }

        public void ChangeChief(Employee newChief)
        {
            this.Chief = newChief;
        }
    }
}