using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;

namespace C_Task7.QuestioF
{
    internal class ChooseOneQuestion:Question
    {
        public ChooseOneQuestion(string header, string body, int marks,
        AnswerList answers, Answer correct)
        : base(header, body, marks, answers, correct) { }

        public override void Display()
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine(Answers[i]);
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);

        }
    }
}
