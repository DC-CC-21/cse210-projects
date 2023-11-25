public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 30;
    }
    public override void Run(Logs logs)
    {
        DisplayStartingMessage();
        GetReady();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        int type = 1;
        while (startTime < futureTime)
        {
            if (type == 1)
            {
                Console.Write("Breathe in... ");
                ShowCountDown(4);
            }
            else
            {
                Console.Write("Breathe out... ");
                ShowCountDown(6);
                Console.WriteLine();
            }
            type *= -1;
            startTime = DateTime.Now;
        }
        DisplayEndingMessage();
        logs.AddLog(_name, _duration);
    }
}