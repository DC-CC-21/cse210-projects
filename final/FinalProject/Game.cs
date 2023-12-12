abstract class Game : References
{
    protected int _maxAttempts;
    protected int _attempts;
    protected string _description;
    protected string _hiddenWord;

    public abstract void Start();
    protected abstract void Run();
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        // Console.CursorVisible = false;
        Console.WriteLine(_description);
        Console.ReadLine();
        // Console.CursorVisible = true;
    }
    protected abstract void DisplayEndingMessage();
    public abstract string GetStringRepresentation();
}