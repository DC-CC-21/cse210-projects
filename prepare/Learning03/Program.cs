using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction a = new();
        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());

        Fraction b = new(5);
        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());

        Fraction c = new(3, 4);
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

        c.SetNumerator(1);
        c.SetDenominator(3);
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

    }
}