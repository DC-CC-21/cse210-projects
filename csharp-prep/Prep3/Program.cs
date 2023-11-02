using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        string answer;
        do
        {

            Random random = new();
            int magicNumber = random.Next(1, 100);//int.Parse(Console.ReadLine());
            int guess;
            int guesses = 0;
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                guesses += 1;

            } while (guess != magicNumber);
            Console.WriteLine($"You guessed it in {guesses} {(guesses == 1 ? "try" : "tries")}!\n");
            Console.Write("Do you want to play again: ");
            answer = Console.ReadLine();
        } while (answer == "yes");
    }
}