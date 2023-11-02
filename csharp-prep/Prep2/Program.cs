using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        float percentage = float.Parse(Console.ReadLine());

        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge
        string symbol = "";
        if (letter != "A" && letter != "F")
        {
            if (percentage % 10 >= 7)
            {
                symbol = "+";
            }
            else if (percentage % 10 < 3)
            {
                symbol = "-";
            }
        }

        // if (percentage >= 70)
        // {
        //     Console.WriteLine("Congratulations you passed the class.");
        // }
        // else
        // {
        //     Console.WriteLine("Better luck next time.");
        // }
        Console.WriteLine(percentage >= 70 ? "Congratulations you passed the class." : "Better luck next time.");
        Console.WriteLine($"{letter}{symbol}");
    }
}
