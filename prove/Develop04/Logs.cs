using System.IO;

public class Logs
{
    private List<string> _logs = new();
    public void AddLog(string name, int duration)
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        string log = $"{date} | {name} | {duration}";
        _logs.Add(log);
        SaveLog(log);
    }
    public void ShowLogs()
    {
        Console.Clear();
        Console.WriteLine("View of this sessions activities. Press enter to return to home\n");
        foreach (string log in _logs)
        {
            Console.WriteLine(log);
        }
        Console.ReadLine();
    }
    public void SaveLog(string log)
    {
        using (StreamWriter outputfile = File.AppendText("mindfulnessLogfile.txt"))
        {
            outputfile.WriteLine(log);
        }
    }
}