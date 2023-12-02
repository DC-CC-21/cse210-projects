public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public override int RecordEvent(int score, bool input = true)
    {
        if (input)
        {
            AddNote();
        }
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        _isComplete = true;
        return score + _points;

    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal&#32{_shortName}&#32{_description}&#32{_points}&#32{IsComplete()}&#32{_note}";
    }
}