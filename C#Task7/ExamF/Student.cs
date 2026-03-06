using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Task7.ExamF
{
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void ReceiveExamNotification(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"[NOTIFICATION FOR {Name}]: The Exam for {e.Subject.Name} is starting now! Time limit: {e.Exam.Time} mins.");
        }
    }
}
