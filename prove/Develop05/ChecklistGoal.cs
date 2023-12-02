using System.Runtime;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amt = 0) : base(name, description, points)
    {
        _amountCompleted = amt;
        _target = target;
        _bonus = bonus;

    }
    public override int RecordEvent(int score, bool input = true)
    {
        if (input)
        {
            AddNote();

        }
        _amountCompleted += 1;
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        if (_amountCompleted % _target == 0)
        {
            Console.WriteLine($"Congratulations! You have earned {_bonus} bonus points");
            return score + _points + _bonus;
        }
        return score + _points;

    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal&#32{_shortName}&#32{_description}&#32{_points}&#32{_amountCompleted}&#32{_target}&#32{_bonus}&#32{_note}";
    }
    public override string GetDetailsString()
    {
        string complete = IsComplete() ? "X" : " ";
        return $"[{complete}] {_shortName} ({_description})  -- Currently completed: {_amountCompleted}/{_target}";
    }
}