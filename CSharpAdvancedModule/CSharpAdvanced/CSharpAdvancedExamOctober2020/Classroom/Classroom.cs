using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return students.Count;
            }
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToDismiss = students.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);

            if (studentToDismiss != null)
            {
                
                students.Remove(students.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName));
                return $"Dismissed student {studentToDismiss.FirstName} {studentToDismiss.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsWithSubject = new List<Student>(students.Where(s => s.Subject == subject));

            StringBuilder sb = new StringBuilder();

            if (studentsWithSubject.Count > 0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students: ");

                foreach (Student student in studentsWithSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().Trim();
            }
            else
            {
               return "No students enrolled for the subject";
            }
           
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student studentToReturn = students.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);
                
             return studentToReturn;
        }

    }
}
