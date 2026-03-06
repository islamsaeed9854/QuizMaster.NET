using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.QuestioF;

namespace C_Task7.ExamF
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, QuestionList questions, Subject subject)
        : base(time, questions, subject)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("=== Practice Exam ===");
            foreach (var q in Questions)
                Console.WriteLine(q);
        }

        public override void Finish()
        {
            base.Finish();

            Console.WriteLine("\n--- Student Answers & Correct Answers ---");
            CorrectExam();
            foreach (var pair in QuestionAnswerDictionary)
            {
                Console.WriteLine($"Question: {pair.Key.Body}");
                foreach (var ans in pair.Value)
                {
                    Console.Write($"{ans} ");
                }
                Console.WriteLine();
                if(pair.Key is ChooseAllQuestion)
                { ChooseAllQuestion c = (ChooseAllQuestion)pair.Key;
                    Console.WriteLine($"Correct Answer:");
                    foreach (var ans in c.correctAns)
                        Console.Write($"{ans} ,");
                }else
                Console.WriteLine($"Correct Answer: {pair.Key.CorrectAnswer}");
                Console.WriteLine();
            }

            Console.WriteLine($"Final Grade: {finalGrade}");
        }
    }
}
