using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;

namespace C_Task7.QuestioF
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks,  Answer correct) 
            : base(header, body, marks, CreateAnswers(), correct)
        {
        }
        private static AnswerList CreateAnswers()
        {
                AnswerList list = new AnswerList();
            list.Add(new Answer(1, "True"));
            list.Add(new Answer(2, "False"));
            return list;
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(CorrectAnswer);
            
        }

        public override void Display()
        {
            Console.WriteLine( ToString());
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine(Answers[i]);
        }

    }
}
