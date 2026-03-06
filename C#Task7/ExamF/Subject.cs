using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Task7.ExamF
{
    internal class Subject
    {
        public string Name { get; set; }

        public Student[] EnrolledStudents { get;  set; }

        private int studentCount = 0;

        public Subject(string name, int capacity)
        {
            Name = name;
            EnrolledStudents = new Student[capacity];
        }

        public void Enroll(Student student,Exam E)
        {
            if (studentCount >= EnrolledStudents.Length)
            {
                Console.WriteLine("No more capacity for students.");
                return;
            }
            E.ExamStarted += student.ReceiveExamNotification;
            EnrolledStudents[studentCount++] = student;
        }
    }
}
