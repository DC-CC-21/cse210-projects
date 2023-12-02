public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected string _note = "";
    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public abstract int RecordEvent(int score, bool input = true);
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        string complete = IsComplete() ? "X" : " ";
        return $"[{complete}] {_shortName} ({_description})";
    }
    public string GetShortName()
    {
        return _shortName;
    }
    protected void AddNote()
    {
        ConsoleOptions consoleOptions = new();
        consoleOptions.DisplayOptions(new List<string>() { "Yes", "No" }, "Would you like to add a note with your accomplishment?");
        if (consoleOptions.GetOptionIndex() == 0)
        {
            Console.WriteLine("Write you note below:");
            _note = Console.ReadLine();
        }
    }
    public void SetNote(string note)
    {
        _note = note;
    }
    public string GetNote()
    {
        return _note;
    }
    public int GetPoints()
    {
        return _points;
    }
    public abstract string GetStringRepresentation();
}