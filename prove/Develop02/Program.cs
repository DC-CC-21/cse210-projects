using System;


class Program
{
    static void Main(string[] args)
    {
        /*
            Exceeds Expectations:
                Wrote a class for handling multiple choice questions in the terminal with arrow keys
                Wrote a function for saving entries so that they can be opened in Excel
                Wrote a function inside of my ConsoleOptions class for handling escapes during keyboard input
        */

        Journal journal = new();
        journal.Run();
    }
}