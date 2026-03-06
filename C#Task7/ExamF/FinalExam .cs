using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.QuestioF;

namespace C_Task7.ExamF
{
    internal class FinalExam:Exam
    {
        public FinalExam(int time, QuestionList questions, Subject subject)
            : base(time, questions, subject)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("=== Final Exam ===");
            foreach (var q in Questions)
            {
                q.Display();
            }
        }

        public override void Finish()
        {
            base.Finish();


            CorrectExam();

            Console.WriteLine("\n--- Student Answers ---");
            foreach (var pair in QuestionAnswerDictionary)
            {
                Console.WriteLine($"Question: {pair.Key.Body}");
                foreach (var ans in pair.Value)
                {
                    Console.Write($"{ans} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Final Grade: {finalGrade}");
        }
    }
}
