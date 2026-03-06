using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Task7.AnswerF;
using C_Task7.QuestioF;

namespace C_Task7.ExamF
{
    internal delegate void ExamStartedHandler(object sender, ExamEventArgs e);

    internal class ExamEventArgs : EventArgs
    {
        public Subject Subject { get; set; }
        public Exam Exam { get; set; }
    }

    internal abstract class Exam :  IComparable<Exam>
    {
        public event ExamStartedHandler ExamStarted;


        public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<Question, Answer[]> QuestionAnswerDictionary { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        protected int finalGrade;

        protected Exam(int time, QuestionList questions, Subject subject)
        {
            Time = time;
            Questions = questions;
            NumberOfQuestions = questions.Count;
            Subject = subject;
            Mode = ExamMode.Queued;

            QuestionAnswerDictionary = new Dictionary<Question, Answer[]>();
        }

        // Abstract
        public abstract void ShowExam();

        // Virtual
        public virtual void Start()
        {
            Mode = ExamMode.Starting;
            // Invoke Event 
            ExamStarted.Invoke(this,new ExamEventArgs() { Subject =  this.Subject, Exam = this });
            Console.WriteLine($"Exam Started for Subject: {Subject.Name}");
            Console.WriteLine($"Duration: {Time} minutes");
            for( int i = 0; i < Questions.Count; i++)
            {
                Questions[i].Display();
                string input=Console.ReadLine();
                Answer[] a;
                while (!check(input, out a))
                {
                    Console.WriteLine( "please Enter valid input");
                    input = Console.ReadLine();
                }
                QuestionAnswerDictionary.Add(Questions[i], a);
                

            }

        }
        private bool check(string s,out Answer[] a)
        {
            string[]n = s.Split(",");
           a = new Answer[n.Length];
            for (int i = 0; i < n.Length; i++)
            {
                int x;
                if (!int.TryParse(n[i], out x))
                {
                    a = null;
                    return false;
                }
                else
                {
                    int y=int.Parse(n[i]);
                    a[i] = new Answer(y, " ");
                }
            }
            return true;

        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("Exam Finished.");
          
        }

        public void CorrectExam()
        {
            finalGrade = 0;

            foreach (var pair in QuestionAnswerDictionary)
            {
                bool t = true;
                foreach (var answer in pair.Value) {
                    t = pair.Key.CheckAnswer(answer);
                    if (pair.Key is ChooseAllQuestion)
                    {
                        ChooseAllQuestion c = (ChooseAllQuestion)pair.Key;
                        if (c.correctAns.Length != pair.Value.Length)
                        { t = false; break; }
                    }
                    
                   
                    if (!t) { 
                        break; }
                }
                if (t) { finalGrade += pair.Key.Marks; }
            }
        }

        // Override ToString
        public override string ToString()
        {
            return $"Subject: {Subject.Name}, Time: {Time}, Questions: {NumberOfQuestions}, Mode: {Mode}";
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Exam other)
            {
                return Time == other.Time &&
                       NumberOfQuestions == other.NumberOfQuestions &&
                       Subject.Name == other.Subject.Name;
            }
            return false;
        }
        public int CompareTo(Exam other)
        {
            if (other == null) return 1;

            int timeComparison = Time.CompareTo(other.Time);

            if (timeComparison != 0)
                return timeComparison;

            return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions,Subject);
        }
    }
}
