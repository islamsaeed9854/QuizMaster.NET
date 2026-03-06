# SharpExam (Console Examination System)

## 📌 Overview
SharpExam is a robust, console-based examination and quiz management system built entirely in C#. It allows educators to create subjects, enroll students, and generate dynamic exams (both Practice and Final) with various question types. The system automatically grades the exams and utilizes an event-driven architecture to notify students when an exam begins.

## 🚀 Features
- **Multiple Question Types:** Supports True/False, Multiple Choice (Choose One), and Multiple Select (Choose All).
- **Exam Modes:** - *Practice Exam:* Shows the student the correct answers and their final grade after completion.
  - *Final Exam:* Strictly records the answers and shows only the final grade.
- **Automated Grading:** The system automatically calculates scores based on assigned question weights.
- **Event Notifications:** Notifies enrolled students in real-time when an exam starts using C# Events and Delegates.
- **File Logging:** Automatically logs all created questions and their options to a local text file (`questions.txt`).
- **Custom Generic Repository:** Features a custom-built, dynamically resizing generic collection (`Repository<T>`) for secure, type-safe data management.

---

## 🏗️ Architecture & Design Decisions

This project was carefully designed to demonstrate core Object-Oriented Programming (OOP) principles, memory management, and advanced C# features.

### 1. Abstraction, Inheritance, and Polymorphism
- **The Question Engine:** At the core is the abstract `Question` class. Specific question types (`ChooseOneQuestion`, `ChooseAllQuestion`, `TrueFalseQuestion`) inherit from this base class. This allows the `Exam` class to hold a generic `QuestionList` and utilize polymorphism to call `.Display()` and `.CheckAnswer()` without needing to know the specific type of question at runtime.
- **The Exam Engine:** Similar to questions, the `Exam` class is abstract. The specific behaviors for grading and displaying results are overridden by the `PracticeExam` and `FinalExam` child classes.

### 2. Generics & Custom Collections (`Repository<T>`)
Instead of relying solely on built-in lists, a custom `Repository<T>` was engineered from scratch.
- **Dynamic Resizing:** Implements under-the-hood array resizing (using `Array.Copy` and capacity doubling) to ensure $O(1)$ amortized insertion time.
- **Generic Constraints:** The repository enforces type safety using `where T : IComparable<T>`, ensuring that any object stored can be properly sorted using `Array.Sort()`.
- **Value Equality:** Uses `EqualityComparer<T>.Default.Equals()` to safely and accurately remove items regardless of whether `T` is a value type or a reference type.

### 3. Event-Driven Architecture (Observer Pattern)
The system utilizes Microsoft's standard Event pattern to decouple the exam execution from student notifications.
- Created a custom `ExamEventArgs` to pass contextual data (the Subject and the Exam details).
- Implemented a `public event ExamStartedHandler ExamStarted;` inside the `Exam` class.
- When an exam calls `.Start()`, it broadcasts this event, automatically triggering the `.ReceiveExamNotification()` method for all dynamically subscribed `Student` objects.

### 4. Operator Overloading & Value Equality
By default, C# compares reference types by their memory address. To make the system more intuitive:
- The `==` and `!=` operators were overloaded in the `Answer` class.
- The `.Equals()` and `.GetHashCode()` methods were overridden.
- This ensures that if two `Answer` objects have the same `id`, they are treated as identical by the system, preventing duplicate answer bugs and making answer-checking highly accurate.

---

## 💻 Tech Stack
- **Language:** C# (.NET 7.0 / .NET 10.0)
- **Paradigm:** Object-Oriented Programming (OOP)
- **Interface:** Console Application

## 🛠️ How to Run
1. Clone the repository:
   ```bash
   git clone [https://github.com/islamsaeed9854/C-Task7.git](https://github.com/islamsaeed9854/C-Task7.git)
