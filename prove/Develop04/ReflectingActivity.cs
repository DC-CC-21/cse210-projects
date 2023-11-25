class ReflectingActivity : Activity
{
    private List<string> _prompts = new(){
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new(){
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 50;
    }
    public override void Run(Logs logs)
    {
        DisplayStartingMessage();
        GetReady();

        Console.WriteLine("Consider the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("When you have something in mind, press enter to continue ");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        while (startTime < futureTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(5);
            Console.WriteLine(" ");
            startTime = DateTime.Now;
        }
        DisplayEndingMessage();
        logs.AddLog(_name, _duration);
    }
    private string GetRandomPrompt()
    {
        Random random = new();
        return _prompts[random.Next(_prompts.Count)];
    }
    private string GetRandomQuestion()
    {
        Random random = new();
        return _questions[random.Next(_questions.Count)];
    }
}