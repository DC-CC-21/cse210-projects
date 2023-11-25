using System;

class Program
{

    /*
        Added the option to view this sessions activities
        Added functionality to save completed activity to a text file
        Added the ability for the user to use arrow keys to choose option

    */

    static void Main(string[] args)
    {
        //activities
        Logs logs = new();
        BreathingActivity breathingActivity = new();
        ReflectingActivity reflectingActivity = new();
        ListingActivity listingActivity = new();

        ConsoleOptions consoleOptions = new();
        List<string> options = new(){
            "Start breathing activity",
            "Start reflecting activity",
            "Start listing activity",
            "Show activity log",
            "Quit"
        };
        int optionIndex = 0;

        do
        {
            consoleOptions.DisplayOptions(options, "Select a choice from the menu");
            optionIndex = consoleOptions.GetOptionIndex();
            if (optionIndex == 0)
            {
                breathingActivity.Run(logs);

            }
            else if (optionIndex == 1)
            {
                reflectingActivity.Run(logs);
            }
            else if (optionIndex == 2)
            {
                listingActivity.Run(logs);
            }
            else if (optionIndex == 3)
            {
                logs.ShowLogs();
            }
        } while (optionIndex != 4);



    }
}