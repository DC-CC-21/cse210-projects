using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        List<int> numbers = new();
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        float average = (float)numbers.Average();
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");

        // Stretch Challenge
        List<float> positive = new();
        foreach (float i in numbers)
        {
            if (i > 0)
            {
                positive.Add(i);
            }
        }
        Console.WriteLine($"The smallest positive number is: {positive.Min()}");

        numbers.Sort();

        foreach (float i in numbers)
        {
            Console.WriteLine(i);
        }

    }
}