using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }

        public Person(string firstName, string lastName, DateTime birtDate, string address, string phoneNum)
        {
            FirstName = firstName;
            LastName = lastName;
            BirtDate = birtDate;
            Address = address;
            PhoneNum = phoneNum;
        }
    }
}
