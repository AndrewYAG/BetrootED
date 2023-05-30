namespace OOPIncapsulationHW
{
    public class Student
    {
        public string Name { get; set; }
        private Group Group { get; set; }

        public Student(string name, Group group)
        {
            Name = name;
            Group = group;
        }

        // set group
        public void SetGroup(Group newGroup)
        {
            this.Group = newGroup;
        }
    }
}