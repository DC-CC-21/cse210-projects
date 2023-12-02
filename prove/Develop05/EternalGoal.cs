public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }
    public override int RecordEvent(int score, bool input = true)
    {
        if (input)
        {
            AddNote();

        }
        Console.WriteLine($"Congratulations! You have earned {_points} points");
        return score + _points;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal&#32{_shortName}&#32{_description}&#32{_points}&#32{IsComplete()}&#32{_note}";
    }
}