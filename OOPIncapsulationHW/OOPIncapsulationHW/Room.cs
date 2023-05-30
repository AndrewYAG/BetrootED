namespace OOPIncapsulationHW
{
    public class Room
    {
        public string Name { get; set; }
        private Lesson Lesson { get; set; }

        public Room(string name, Lesson lesson)
        {
            Name = name;
            Lesson = lesson;
        }

        // set lesson
        public void SetLesson(Lesson newLesson)
        {
            this.Lesson = newLesson;
        }
    }
}