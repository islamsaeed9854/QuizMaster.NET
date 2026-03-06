using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;

namespace C_Task7.QuestioF
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        public Question(string header, string body, int marks, AnswerList answers, Answer correct)
        {
            if (marks > 0)
            {
                if (header != null && body != null && answers != null && correct != null)
                {
                    Header = header;
                    Body = body;
                    Answers = answers;
                    CorrectAnswer = correct;
                    Marks = marks;
                }
                else { throw new ArgumentNullException(); }
            }
            else { throw new ArgumentException("Marks must be > 0"); }

        }
        public abstract void Display();
        public abstract bool CheckAnswer(Answer studentAnswer);
        public override string ToString()
        {
            return $"{Header}\n{Body}\nMarks: {Marks}";
        }
        public override bool Equals(object? obj)
        {
            if(obj is Question quest)
            {
                if (Header == quest.Header && Body == quest.Body )
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Body,Header,Marks);
        }

    }
}
