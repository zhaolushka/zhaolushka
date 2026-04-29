using System;
using System.Linq;

class Student
{
    private static int nextId = 1;

    public int StudentId { get; private set; }
    public string Name { get; set; }

    private double gpa;
    public double GPA
    {
        get { return gpa; }
        set
        {
            if (value >= 0.0 && value <= 4.0)
                gpa = value;
            else
                Console.WriteLine("Invalid GPA! Must be between 0.0 and 4.0");
        }
    }

    public string Faculty { get; set; }

    public Student(string name, double gpa, string faculty)
    {
        StudentId = nextId++;
        Name = name;
        GPA = gpa;
        Faculty = faculty;
    }

    public void Print()
    {
        Console.WriteLine($"ID: {StudentId}, Name: {Name}, GPA: {GPA}, Faculty: {Faculty}");
    }
}

class Registry
{
    private Student[] students = new Student[100];
    private int count = 0;

    public void Add(Student student)
    {
        if (count >= 100)
        {
            Console.WriteLine("Registry is full!");
            return;
        }

        students[count++] = student;
        Console.WriteLine("Student added successfully!");
    }

    public Student FindById(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == id)
                return students[i];
        }
        return null;
    }

    public Student[] FindByName(string name)
    {
        return students
            .Take(count)
            .Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public Student[] GetTopStudents(int n)
    {
        return students
            .Take(count)
            .OrderByDescending(s => s.GPA)
            .Take(n)
            .ToArray();
    }

    public void PrintAll()
    {
        if (count == 0)
        {
            Console.WriteLine("No students in registry.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            students[i].Print();
        }
    }
}

class Program
{
    static void Main()
    {
        Registry registry = new Registry();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Student Registry ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Find by ID");
            Console.WriteLine("3. Find by Name");
            Console.WriteLine("4. Top N Students");
            Console.WriteLine("5. Print All");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("GPA: ");
                    if (!double.TryParse(Console.ReadLine(), out double gpa))
                    {
                        Console.WriteLine("Invalid GPA input!");
                        break;
                    }

                    Console.Write("Faculty: ");
                    string faculty = Console.ReadLine();

                    Student student = new Student(name, gpa, faculty);
                    registry.Add(student);
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var found = registry.FindById(id);
                        if (found != null)
                            found.Print();
                        else
                            Console.WriteLine("Student not found.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;

                case "3":
                    Console.Write("Enter Name: ");
                    string searchName = Console.ReadLine();

                    var results = registry.FindByName(searchName);

                    if (results.Length == 0)
                        Console.WriteLine("No students found.");
                    else
                        foreach (var s in results)
                            s.Print();
                    break;

                case "4":
                    Console.Write("Enter N: ");
                    if (int.TryParse(Console.ReadLine(), out int n))
                    {
                        var top = registry.GetTopStudents(n);
                        foreach (var s in top)
                            s.Print();
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case "5":
                    registry.PrintAll();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
