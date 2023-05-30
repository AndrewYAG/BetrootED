using System.Text.RegularExpressions;

namespace OOPIncapsulationHW
{
    public class Lesson
    {
        private Group[] groups = new Group[0];
        public string Name { get; set; }
        private Teacher Teacher { get; set; }
        private Room Room { get; set; }

        public Lesson(Group[] groups, string name, Teacher teacher, Room room)
        {
            this.groups = groups;
            Name = name;
            Teacher = teacher;
            Room = room;
        }

        // set room
        public void SetRoom(Room newRoom)
        {
            this.Room = newRoom;
        }

        // set teacher
        public void SetTeacher(Teacher newTeacher)
        {
            this.Teacher = newTeacher;
        }

        // add, remove groups
        public void AddGroup(Group newGroup)
        {
            Array.Resize(ref groups, groups.Length + 1);
            groups[groups.Length - 1] = newGroup;
        }
        public void RemoveGroup(Group groupToRemove)
        {
            Group[] tempGroup = new Group[groups.Length];
            Array.Copy(groups, tempGroup, groups.Length);
            Array.Resize(ref groups, groups.Length - 1);

            int index = 0;
            for (int i = 0; i < tempGroup.Length; i++)
            {
                if (groupToRemove.Name == tempGroup[i].Name)
                    continue;

                groups[index++] = tempGroup[i];
            }
        }
    }
}