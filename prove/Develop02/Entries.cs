class Entries
{
    private List<List<string>> _entries = new();
    private readonly List<string> _options = new(){
        "View Prompt",
        "Skip Prompt"
    };
    private readonly Prompt _prompt = new();
    private readonly ConsoleOptions _consoleOptions = new();

    public void DisplayOption()
    {
        _consoleOptions.DisplayOptions(_options, "Would you like to view a writing prompt to get started");
        string selected = _consoleOptions.GetOption();
        if (selected == "")
        {
            return;
        }

        Console.Clear();
        Console.WriteLine("Write something below to record it in your journal.");

        string prompt = "Skipped prompt";
        if (selected == "View Prompt")
        {
            prompt = _prompt.SelectRandomPrompt();
            Console.WriteLine(prompt);
        }

        string response = Console.ReadLine();
        WriteEntry(response, prompt);
    }
    public void WriteEntry(string response, string prompt)
    {
        DateTime currentDate = DateTime.Now;
        string dateText = currentDate.ToShortDateString();
        List<string> values = new() { dateText, prompt, response };
        _entries.Add(values);
    }
    public void DisplayEntries()
    {
        Console.Clear();
        Console.WriteLine("Your Entries");
        Console.WriteLine("Press any key to continue\n");
        if (_entries.Count == 0)
        {
            Console.WriteLine("You have no entries yet.");
        }
        else
        {
            int index = 0;
            foreach (List<string> entry in _entries)
            {
                index += 1;
                Console.WriteLine($"\n{index}.  Date: {entry[0]} - Prompt: {entry[1]}\n    {entry[2]}");
            };
        }

        Console.ReadKey(true);
    }
    public void DeleteEntry()
    {
        Console.Clear();
        if (_entries.Count == 0)
        {
            Console.WriteLine("You don't have any entries to delete.");
            Console.ReadKey(true);
        }
        else
        {

            List<string> stringEntries = new();
            int index = 0;
            foreach (List<string> entry in _entries)
            {
                index += 1;
                string value = $"\n{index}.  Date: {entry[0]} - Prompt: {entry[1]}\n    {entry[2]}";
                stringEntries.Add(value);
            }

            _consoleOptions.DisplayOptions(stringEntries, "Choose an entry to delete");
            int optionIndex = _consoleOptions.GetOptionIndex();
            if(optionIndex == -1){
                return;
            }
            _entries.RemoveAt(optionIndex);
            DisplayEntries();
        }
    }
    public List<List<string>> GetEntries() => _entries;
    public void SetEntries(List<List<string>> newEntries) => _entries = newEntries;
}

