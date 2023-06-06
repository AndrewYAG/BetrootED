namespace AbstractAndInterfacesHW
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Address { get; private set; }
        public string PhoneNum { get; private set; }
        public string Email { get; private set; }

        public Person(string firstName, string lastName, DateTime birthDate, string address, string phoneNum, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Address = address;
            PhoneNum = phoneNum;
            Email = email;
        }
    }



}