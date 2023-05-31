namespace ConsoleApp1
{
    public class OflineService
    {
        protected Employee[] employees = new Employee[0];
        public string Title { get; set; }
        public string Address { get; set; }
        public string ContactNum { get; set; }
        public void AddEmployee(Employee newEmployee)
        {
            Array.Resize(ref employees, employees.Length + 1);
            employees[employees.Length - 1] = newEmployee;
        }
        public void ShowAllEmployees()
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}