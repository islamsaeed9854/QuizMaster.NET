using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;

namespace C_Task7.QuestioF
{
    internal class QuestionList : List<Question>
    {
        private string filePath;



        private int count = 0;

        public QuestionList(string filePath)
        {
            this.filePath = filePath;

        }


        public new void Add(Question question)
        {




             base.Add(question);


            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(question);
                for (int i = 0; i < question.Answers.Count; i++)
                    sw.WriteLine(question.Answers[i]);
                sw.WriteLine();
            }


        }
    }
}
