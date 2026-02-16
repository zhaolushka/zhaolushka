using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter movie title: ");
        string movieTitle = Console.ReadLine();

        Console.Write("Enter number of tickets: ");
        int numberOfTickets = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter price per ticket: ");
        double pricePerTicket = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter duration of movie (hours): ");
        double duration = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter screen number: ");
        int screenNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter first letter of seat row: ");
        char seatRow = Convert.ToChar(Console.ReadLine());

        Console.Write("Is it a 3D movie? (true/false): ");
        bool is3D = Convert.ToBoolean(Console.ReadLine());

        double totalCost = numberOfTickets * pricePerTicket;
        double costPerHour = totalCost / duration;

        Console.WriteLine("\n--- Cinema Ticket Info ---");
        Console.WriteLine("Movie: " + movieTitle);
        Console.WriteLine("Tickets: " + numberOfTickets);
        Console.WriteLine("Price per ticket: " + pricePerTicket);
        Console.WriteLine("Duration: " + duration + " hours");
        Console.WriteLine("Screen number: " + screenNumber);
        Console.WriteLine("Seat row: " + seatRow);
        Console.WriteLine("3D Movie: " + is3D);

        Console.WriteLine("\n--- Calculations ---");
        Console.WriteLine("Total ticket cost: " + totalCost);
        Console.WriteLine("Cost per hour: " + costPerHour);

        Console.WriteLine("\n--- Data Types ---");
        Console.WriteLine(numberOfTickets.GetType());
        Console.WriteLine(pricePerTicket.GetType());
        Console.WriteLine(is3D.GetType());

        int roundedCost = (int)totalCost;
        Console.WriteLine("\nRounded total cost: " + roundedCost);

        Console.ReadLine();
    }
}
