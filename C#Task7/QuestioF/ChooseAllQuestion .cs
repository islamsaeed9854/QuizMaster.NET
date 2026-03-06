using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;

namespace C_Task7.QuestioF
{
    internal class ChooseAllQuestion:Question    {
       public Answer[] correctAns; 
        public ChooseAllQuestion(string header, string body, int marks,
        AnswerList answers, Answer[] correct)
        : base(header, body, marks, answers, correct[0]) { 
        correctAns=correct;
        
        }

        public override void Display()
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine(Answers[i]);
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            for (int i = 0;i < correctAns.Length; i++)
            {
                if(correctAns[i].Equals( studentAnswer))
                    return true;
            }
            return false;

        }
    }
}
