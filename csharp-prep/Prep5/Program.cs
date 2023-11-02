using System;


class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userNumberSq = SquareNumber(userNumber);
        DisplayResult(userName, userNumberSq);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        return (int)Math.Pow(number, 2);
    }
    static void DisplayResult(string userName, int userNumberSq)
    {
        Console.WriteLine($"{userName}, the square of your number is {userNumberSq}");
    }
}