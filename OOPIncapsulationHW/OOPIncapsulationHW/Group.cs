using System.Text.RegularExpressions;

namespace OOPIncapsulationHW
{
    public class Group
    {
        private Student[] students = new Student[0];
        private Lesson[] lessons = new Lesson[0];
        public string Name { get; set; }
        private Cathedra Cathedra { get; set; }

        public Group(Student[] students, Lesson[] lessons, string name, Cathedra cathedra)
        {
            this.students = students;
            this.lessons = lessons;
            Name = name;
            Cathedra = cathedra;
        }

        // set cathedra
        public void SetCathedra(Cathedra newCathedra)
        {
            this.Cathedra = newCathedra;
        }

        // add, remove students
        public void AddStudent(Student newStudent)
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = newStudent;
        }
        public void RemoveStudent(Student studentToRemove)
        {
            Student[] tempStudent = new Student[students.Length];
            Array.Copy(students, tempStudent, students.Length);
            Array.Resize(ref students, students.Length - 1);

            int index = 0;
            for (int i = 0; i < tempStudent.Length; i++)
            {
                if (studentToRemove.Name == tempStudent[i].Name)
                    continue;

                students[index++] = tempStudent[i];
            }
        }

        // add, remove lessons
        public void AddLesson(Lesson newLesson)
        {
            Array.Resize(ref lessons, lessons.Length + 1);
            lessons[lessons.Length - 1] = newLesson;
        }
        public void RemoveLesson(Lesson lessonToRemove)
        {
            Student[] tempStudent = new Student[lessons.Length];
            Array.Copy(lessons, tempStudent, lessons.Length);
            Array.Resize(ref lessons, lessons.Length - 1);

            int index = 0;
            for (int i = 0; i < tempStudent.Length; i++)
            {
                if (lessonToRemove.Name == tempStudent[i].Name)
                    continue;

                students[index++] = tempStudent[i];
            }
        }

    }
}