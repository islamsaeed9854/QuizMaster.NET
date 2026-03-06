using C_Task7.AnswerF;
using C_Task7.ExamF;
using C_Task7.QuestioF;

namespace C_Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("OOp",10);
            Student s1 = new Student(1,"Ali");
            Student s2 = new Student(2,"Sara");

            
            QuestionList questions = new QuestionList("questions.txt");
            //choose one
            AnswerList chooseOneAnswers = new AnswerList();
            chooseOneAnswers.Add(new Answer(1, "Encapsulation"));
            chooseOneAnswers.Add(new Answer(2, "Compilation"));
            chooseOneAnswers.Add(new Answer(3, "Encryption"));

            Question q1 = new ChooseOneQuestion(
                "Q1",
                "Which is a pillar of OOP?",
                5,
                chooseOneAnswers,
                new Answer(1, "Encapsulation")
            );

            questions.Add(q1);
            //choose All
            AnswerList chooseAllAnswers = new AnswerList();
            chooseAllAnswers.Add(new Answer(1, "Inheritance"));
            chooseAllAnswers.Add(new Answer(2, "Polymorphism"));
            chooseAllAnswers.Add(new Answer(3, "HTML"));
            chooseAllAnswers.Add(new Answer(4, "Encapsulation"));

            Answer[] correctAll =
            {
                new Answer(1, "Inheritance"),
                new Answer(2, "Polymorphism"),
                new Answer(4, "Encapsulation")
            };

            Question q2 = new ChooseAllQuestion(
                "Q2",
                "Select OOP principles:",
                10,
                chooseAllAnswers,
                correctAll
            );

            questions.Add(q2);
            //T/F
            Question q3 = new TrueFalseQuestion(
               "Q3",
               "C# supports object oriented programming.",
               5,
               new Answer(1, "True")
           );

            questions.Add(q3);
            PracticeExam practice = new PracticeExam(60, questions, subject);

            FinalExam finalExam = new FinalExam(90, questions, subject);

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1 - Practice");
            Console.WriteLine("2 - Final");
            
            string choice = Console.ReadLine();
            while (choice !="1"&&choice !="2")
            {
                    Console.WriteLine("Invalid choice.try again..");
                choice = Console.ReadLine();
            }
            if (choice == "1")
            {
                subject.Enroll(s1, practice);
                subject.Enroll(s2,practice);
                practice.Start();
                practice.Finish();
            }
            else if (choice == "2")
            {
                subject.Enroll(s1, finalExam);
                subject.Enroll(s2, finalExam);
                finalExam.Start();
                finalExam.Finish();
            }



            Console.WriteLine("--- Testing Repository<Answer> ---");

           
            Repository<Answer> answerRepo = new Repository<Answer>();

            
            Answer a1 = new Answer(3, "Polymorphism");
            Answer a2 = new Answer(1, "Encapsulation");
            Answer a3 = new Answer(2, "Inheritance");
            Answer a4 = new Answer(4, "Abstraction");

            
            Console.WriteLine("Adding answers...");
            answerRepo.Add(a1);
            answerRepo.Add(a2);
            answerRepo.Add(a3);
            answerRepo.Add(a4);

            
            PrintRepo(answerRepo);

            
            Console.WriteLine("\nRemoving Answer with ID 2 (Inheritance)...");
            answerRepo.Remove(a3);
            PrintRepo(answerRepo);

           
            Console.WriteLine("\nSorting the repository by Answer ID...");
            answerRepo.Sort();
            PrintRepo(answerRepo);
        }

       
        static void PrintRepo(Repository<Answer> repo)
        {
            Console.WriteLine($"Current Count: {repo.Count}");
            Answer[] allAnswers = repo.GetAll();

            foreach (Answer ans in allAnswers)
            {
                
                Console.WriteLine($" - {ans}");
            }
        }

    }
    
}
