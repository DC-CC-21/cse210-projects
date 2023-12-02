using System;

class Program
{
    /*
        Added ability for users to add notes to goals that they recored events to.
        Added ability for users to only accomplish goals that have not already been accomplished
        Added ability for users to remove goals
    */
    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        ConsoleOptions consoleOptions = new();
        List<string> menuOptions = new(){
            "Create New Goal",
            "List Goals",
            "Save Goals",
            "Load Goals",
            "Record Event",
            "View Notes",
            "Remove Goal",
            "Quit"

        };

        bool playing = true;
        do
        {
            consoleOptions.DisplayOptions(menuOptions, $"Points: {goalManager.GetPoints()}\n\nMenu Options");

            string option = consoleOptions.GetOption().Split(" ")[0];
            if (option == "Create")
            {
                goalManager.CreateGoal(consoleOptions);
            }
            else if (option == "List")
            {
                goalManager.DisplayPlayerInfo();
            }
            else if (option == "Save")
            {
                goalManager.SaveGoals();
            }
            else if (option == "Load")
            {
                goalManager.LoadGoals();
            }
            else if (option == "Record")
            {
                goalManager.RecordEvent(consoleOptions);
            }
            else if (option == "View")
            {
                goalManager.ViewNotes();
            }
            else if (option == "Remove")
            {
                goalManager.RemoveGoal(consoleOptions);
            }
            else if (option == "Quit")
            {
                break;
            }
        } while (playing == true);
    }
}