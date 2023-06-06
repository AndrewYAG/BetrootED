namespace AbstractAndInterfacesHW
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Position { get; set; }
        public Employee Chief { get; set; }

        public Employee(string firstName, string lastName, DateTime birthDate, string address, string phoneNum, string email,
            int salary, string position, Employee chief) 
            : base(firstName, lastName, birthDate, address, phoneNum, email)
        {
            Salary = salary;
            Position = position;
            Chief = chief;
        }
    }



}