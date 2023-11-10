using System.Text.RegularExpressions;

class Journal
{
    private readonly ConsoleOptions _consoleOptions = new();
    private readonly Entries _entries = new();
    private readonly List<string> _options = new(){
        "Write new Entry",
        "Display Entries",
        "Load Entries",
        "Save Entries",
        "Delete Entry",
        "Quit"
    };
    private bool _exit = false;
    private static List<List<string>> ParseCSV(string filepath)
    {
        string[] lines = File.ReadAllLines(filepath);
        List<List<string>> newEntries = new();
        foreach (string line in lines)
        {
            //check if value is surrounded by quotes
            MatchCollection matches = Regex.Matches(line, "\"[^\"]*\"");
            string lineCopy = line;

            // replace each matches comma with html code for comma
            foreach (Match i in matches)
            {
                lineCopy = lineCopy.Replace(i.ToString(), i.ToString().Replace(",", "&#44"));
            }

            //now that the misleading commas are gone split the list into parts
            List<string> parts = lineCopy.Split(",").ToList();

            // replace html code for comma with an actual comma
            for (int i = 0; i < parts.Count; i++)
            {
                parts[i] = parts[i].Replace("&#44", ",").Replace("\"", "");
            }


            newEntries.Add(parts);
        }
        return newEntries;
    }

    void LoadFile(int error = 200)
    {
        Console.Clear();
        if (error == 404)
        {
            Console.WriteLine("File not found");
        }
        string filepath = _consoleOptions.ReadLineWithEscape("Please type the path to your csv file. Type use the escape key to cancel");
        if (filepath == null)
        {
            return;
        }
        else if (filepath == "")
        {
            LoadFile(404);
        }
        else
        {
            _entries.SetEntries(ParseCSV(filepath));
            _entries.DisplayEntries();
        }
    }
    void SaveFile()
    {
        Console.Clear();
        List<string> entryData = new();
        foreach (List<string> entry in _entries.GetEntries())
        {
            List<string> entryValue = new();
            for (int i = 0; i < entry.Count; i++)
            {
                if (entry[i].Contains(','))
                {
                    entryValue.Add($"\"{entry[i]}\"");
                }
                else
                {
                    entryValue.Add(entry[i]);
                }
            }
            entryData.Add(string.Join(",", entryValue.ToArray()));
        }

        string value = _consoleOptions.ReadLineWithEscape("Type filename. (do not type file extension). Use the escape key if you would like to return to home.");
        if (value == null)
        {
            return;
        }
        string filename = $"{value}.csv";
        using (StreamWriter outputFile = new(filename))
        {
            foreach (string entry in entryData)
            {
                outputFile.WriteLine(entry);
            }
        }

        Console.WriteLine("File saved. Type any key to continue");
        Console.ReadKey(true);
    }
    void ChooseOption(string selected)
    {
        if (selected == "Write new Entry")
        {
            _entries.DisplayOption();
        }
        else if (selected == "Display Entries")
        {
            _entries.DisplayEntries();
        }
        else if (selected == "Load Entries")
        {
            LoadFile();
        }
        else if (selected == "Save Entries")
        {
            SaveFile();
        }
        else if (selected == "Delete Entry")
        {
            _entries.DeleteEntry();
        }
        else if (selected == "Quit")
        {
            _exit = true;
        }
    }
    public void Run()
    {
        while (!_exit)
        {
            _consoleOptions.DisplayOptions(_options, "What would you like to do?");
            ChooseOption(_consoleOptions.GetOption());
        }
    }
}