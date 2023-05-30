namespace ClassIntroHW
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Position { get; set; }
        public Employee Chief { get; set; }
        
        public void ChangeChief(Employee newChief)
        {
            this.Chief = newChief;
        }
    }
}