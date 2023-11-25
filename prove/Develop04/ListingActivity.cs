public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new() {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 30;
    }
    public override void Run(Logs logs)
    {
        DisplayStartingMessage();
        GetReady();

        Console.WriteLine("List as many responses you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in ");
        ShowCountDown(5);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        while (startTime < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count += 1;
            startTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
        logs.AddLog(_name, _duration);
    }
    private string GetRandomPrompt()
    {
        Random random = new();
        return _prompts[random.Next(_prompts.Count)];
    }
}