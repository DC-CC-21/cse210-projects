using System;


class Program
{
    static void Main(string[] args)
    {
        /*
            Exceeds Expectations:
                Wrote a class for handling multiple choice questions in the terminal with arrow keys
                Wrote a function for saving entries as a csv that can be opened in Excel
                Wrote a function inside of my ConsoleOptions class for handling escapes during keyboard input
                Added functionality for the user to choose if the want to see the prompt
                Added functionality for the user to delete an entry
                
        */

        Journal journal = new();
        journal.Run();
    }
}