using System;

class Student
{
    public string Name { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
    public int Grade3 { get; set; }

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverage();

        if (avg >= 90) return "A";
        if (avg >= 75) return "B";
        if (avg >= 60) return "C";
        return "F";
    }

    public void Print()
    {
        Console.WriteLine($"{Name} {GetAverage():F2} {GetLetterGrade()}");
    }
}

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialDeposit)
    {
        if (initialDeposit < 0) throw new ArgumentException();
        Owner = owner;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException();
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException();
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
        Balance -= amount;
    }

    public void PrintStatement()
    {
        Console.WriteLine($"{Owner} {Balance}");
    }
}

class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15) throw new ArgumentException();
            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get => _celsius * 9 / 5 + 32;
        set => Celsius = (value - 32) * 5 / 9;
    }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    public void Print()
    {
        Console.WriteLine($"{Celsius}°C / {Fahrenheit}°F");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[]
        {
            new Student { Name = "A", Grade1 = 90, Grade2 = 85, Grade3 = 88 },
            new Student { Name = "B", Grade1 = 70, Grade2 = 75, Grade3 = 72 },
            new Student { Name = "C", Grade1 = 95, Grade2 = 92, Grade3 = 96 },
            new Student { Name = "D", Grade1 = 60, Grade2 = 65, Grade3 = 63 }
        };

        foreach (var s in roster)
            s.Print();

        Student best = roster[0];
        foreach (var s in roster)
            if (s.GetAverage() > best.GetAverage())
                best = s;

        Console.WriteLine($"Best: {best.Name} {best.GetAverage():F2}");

        var acc = new BankAccount("Alice", 100m);
        acc.Deposit(50m);
        acc.Withdraw(30m);
        acc.PrintStatement();

        try
        {
            acc.Withdraw(1000m);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        var temp = new Temperature(25);
        temp.Print();
        temp.Fahrenheit = 100;
        temp.Print();

        try
        {
            temp.Celsius = -300;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
