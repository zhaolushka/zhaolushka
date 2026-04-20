using System;

namespace StudentRosterApp
{
    class Student
    {
        public string Name { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }

        public Student(string name, int g1, int g2, int g3)
        {
            Name = name;
            Grade1 = g1;
            Grade2 = g2;
            Grade3 = g3;
        }

        public double GetAverage()
        {
            return (Grade1 + Grade2 + Grade3) / 3.0;
        }

        public string GetLetterGrade()
        {
            double avg = GetAverage();

            if (avg >= 90) return "A";
            else if (avg >= 75) return "B";
            else if (avg >= 60) return "C";
            else return "F";
        }

        public void Print()
        {
            Console.WriteLine($"{Name} - Avg: {GetAverage():F2}, Grade: {GetLetterGrade()}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] roster = new Student[4]
            {
                new Student("Aruzhan", 95, 88, 91),
                new Student("Dias", 72, 78, 80),
                new Student("Aigerim", 60, 65, 58),
                new Student("Madi", 85, 90, 87)
            };


            foreach (Student s in roster)
            {
                s.Print();
            }


            Student best = roster[0];

            for (int i = 1; i < roster.Length; i++)
            {
                if (roster[i].GetAverage() > best.GetAverage())
                {
                    best = roster[i];
                }
            }

            Console.WriteLine("\nTop Student:");
            best.Print();
        }
    }
}
