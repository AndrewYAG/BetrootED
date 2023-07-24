namespace LinkControlHW.Contracts
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;
        }
        public Room(string name, int id) : this(name)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Room: {Name}";
        }
    }
}