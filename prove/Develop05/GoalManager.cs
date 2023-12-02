public class GoalManager
{
    private List<Goal> _goals = new();
    List<string> _goalOptions = new(){
        "Simple Goal",
        "Eternal Goal",
        "Checklist Goal"
    };
    private int _score;

    public GoalManager()
    {
        _score = 0;
    }
    public void Start()
    {

    }
    public void DisplayPlayerInfo()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("The goals are: ");

        int index = 0;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index += 1;
        }

        Console.WriteLine($"\nScore: {_score}\n");
        Console.Write("Press enter to continue");

        Console.ReadLine();
        Console.CursorVisible = true;

    }
    public List<string> GetIncompleteGoalNames()
    {
        List<string> goalNames = new();
        int index = 0;
        foreach (Goal goal in _goals)
        {
            if (!goal.IsComplete())
            {
                goalNames.Add($"{index}. {goal.GetShortName()}");
            }
            index += 1;
        }
        return goalNames;
    }
    public void CreateGoal(ConsoleOptions consoleOptions)
    {
        consoleOptions.DisplayOptions(_goalOptions, "What type of goal would you like to create");
        string goalOption = consoleOptions.GetOption().Split(" ")[0];
        List<string> details = GetNameDescPoints();
        if (goalOption == "Simple")
        {
            _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
        }
        else if (goalOption == "Eternal")
        {
            _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
        }
        else if (goalOption == "Checklist")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), target, bonus));
        }
    }
    private List<string> GetNameDescPoints()
    {
        List<string> details = new();

        Console.Write("What is the name of you goal? ");
        string name = Console.ReadLine();
        details.Add(name);

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        details.Add(description);

        Console.Write("What is the amount of points associated with the goal? ");
        string points = Console.ReadLine();
        details.Add(points);

        return details;
    }
    public void RecordEvent(ConsoleOptions consoleOptions)
    {
        Console.Clear();
        Console.CursorVisible = false;
        List<string> goalNames = GetIncompleteGoalNames();
        if (goalNames.Count == 0)
        {
            Console.WriteLine("You have no incomplete goals. Press enter to continue");
            Console.ReadLine();
            Console.CursorVisible = true;
            return;
        }

        consoleOptions.DisplayOptions(goalNames, "Which goal would you like to record");

        int goalIndex = int.Parse(consoleOptions.GetOption().Split(". ")[0]);
        Goal goal = _goals[goalIndex];
        _score = goal.RecordEvent(_score);

        Console.WriteLine($"You now have {_score} points. Press enter to continue");
        Console.ReadLine();
        Console.CursorVisible = true;
    }
    public void RemoveGoal(ConsoleOptions consoleOptions)
    {
        Console.Clear();
        Console.CursorVisible = false;
        List<string> goalNames = new();
        foreach (Goal goal1 in _goals)
        {
            goalNames.Add(goal1.GetShortName());
        }
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals. Press enter to continue");
            Console.ReadLine();
            Console.CursorVisible = true;
            return;
        }

        consoleOptions.DisplayOptions(goalNames, "Which goal would you like to remove");

        int goalIndex = consoleOptions.GetOptionIndex();
        _goals.RemoveAt(goalIndex);

        Console.WriteLine($"Goal {goalNames[goalIndex]} was removed. Press enter to continue");
        Console.ReadLine();
        Console.CursorVisible = true;
    }
    public void ViewNotes()
    {
        Console.Clear();
        Console.WriteLine("Your notes. Press enter to exit\n");
        foreach (Goal goal in _goals)
        {
            if (goal.GetNote() != "")
            {
                Console.WriteLine(goal.GetDetailsString());
                Console.WriteLine(goal.GetNote());
                Console.WriteLine();
            }
        }
        Console.ReadKey();
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        _goals = new();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        int index = 0;
        using (StreamReader reader = new(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (index == 0)
                {
                    _score = int.Parse(line);
                }
                else
                {
                    string[] parts = line.Split("&#32");

                    if (parts[0] == "SimpleGoal" || parts[0] == "EternalGoal")
                    {
                        Goal goal;
                        if (parts[0] == "SimpleGoal")
                        {
                            goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        }
                        else
                        {
                            goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        }


                        if (bool.Parse(parts[4]))
                        {
                            _score = goal.RecordEvent(_score, false);
                        }
                        goal.SetNote(parts[5]);
                        _goals.Add(goal);
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        Goal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[4]));
                        goal.SetNote(parts[7]);
                        _goals.Add(goal);

                    }
                    Console.WriteLine();
                }
                index += 1;
            }
        }
    }
    public int GetPoints()
    {
        return _score;
    }
}