using System;

namespace OOPIncapsulationHW
{
    public class Cathedra
    {
        private Group[] groups = new Group[0];
        private Teacher[] teachers = new Teacher[0];
        public string Name { get; set; }

        public Cathedra(Group[] groups, Teacher[] teachers, string name)
        {
            this.groups = groups;
            this.teachers = teachers;
            Name = name;
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

        // add, remove teachers
        public void AddTeacher(Teacher newTeacher)
        {
            Array.Resize(ref teachers, teachers.Length + 1);
            teachers[groups.Length - 1] = newTeacher;
        }
        public void RemoveTeacher(Teacher teacherToRemove)
        {
            Teacher[] tempTeachers = new Teacher[teachers.Length];
            Array.Copy(teachers, tempTeachers, teachers.Length);

            Array.Resize(ref teachers, teachers.Length - 1);

            int index = 0;
            for (int i = 0; i < tempTeachers.Length; i++)
            {
                if (teacherToRemove.Name == tempTeachers[i].Name)
                    continue;

                teachers[index++] = tempTeachers[i];
            }
        }
    }
}