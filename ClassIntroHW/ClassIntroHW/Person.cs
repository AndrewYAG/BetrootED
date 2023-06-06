namespace ClassIntroHW
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }

        public Person(string firstName, string lastName, int age, DateTime birthDate, string address, string phoneNum)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BirthDate = birthDate;
            Address = address;
            PhoneNum = phoneNum;
        }
    }
}