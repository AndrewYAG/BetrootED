namespace OOPIncapsulationHW
{
    public class Teacher
    {
        public string Name { get; set; }
        private Cathedra Cathedra { get; set; }

        public Teacher(string name, Cathedra cathedra)
        {
            Name = name;
            Cathedra = cathedra;
        }

        // set cathedra
        public void SetCathedra(Cathedra newCathedra)
        {
            this.Cathedra = newCathedra;
        }
    }
}