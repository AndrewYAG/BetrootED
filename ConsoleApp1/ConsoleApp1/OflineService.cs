namespace ConsoleApp1
{
    public class OflineService
    {
        protected Employee[] _employees = new Employee[0];
        public string Title { get; set; }
        public string Address { get; set; }
        public string ContactNum { get; set; }

        public OflineService(string title, string address, string contactNum)
        {
            Title = title;
            Address = address;
            ContactNum = contactNum;
        }
        public OflineService(Employee[] employees, string title, string address, string contactNum) 
            : this(title, address, contactNum)
        {
            _employees = employees;
        }

        public void AddEmployee(Employee newEmployee)
        {
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = newEmployee;
        }
        public void ShowAllEmployees()
        {
            foreach (var emp in _employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}