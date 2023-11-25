public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    private List<string> _animationFrames = new(){
        "|",
        "/",
        "-",
        "\\",
    };

    public Activity() { }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!\n");
        ShowSpinner(2);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner(2);

    }
    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        int animationFrame = 0;


        Console.CursorVisible = false;
        while (startTime < futureTime)
        {
            Console.Write($"{_animationFrames[animationFrame]}\b");
            Thread.Sleep(200);
            animationFrame += 1;
            if (animationFrame >= _animationFrames.Count)
            {
                animationFrame = 0;
            }
            startTime = DateTime.Now;
        }
        Console.CursorVisible = true;
    }
    protected void GetReady()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine(" \n");
    }
    protected void ShowCountDown(int seconds)
    {
        Console.CursorVisible = false;
        int second = seconds;
        while (second > 0)
        {
            Console.Write($"{second}\b");
            second--;
            Thread.Sleep(1000);
        }
        Console.WriteLine(" ");
        Console.CursorVisible = true;
    }
    public abstract void Run(Logs logs);

}