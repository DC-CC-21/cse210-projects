class DataManager
{
    private List<string> _scores = new();

    public void LoadData()
    {
        try
        {
            using (StreamReader streamReader = new("gameData.txt", true))
            {
                while (!streamReader.EndOfStream)
                {
                    _scores.Add(streamReader.ReadLine());
                }
            }
        }
        catch
        {
            // do nothing
        }
    }
    public static void SaveData(string stringRepresentation)
    {
        using (StreamWriter streamWriter = new("gameData.txt", true))
        {
            streamWriter.WriteLine(stringRepresentation);
        }
    }
    public void ShowScores()
    {
        Console.Clear();
        if (_scores.Count > 0)
        {
            foreach (string score in _scores)
            {
                string[] scoreParts = score.Split(" : ");
                string details = scoreParts[0] == "WordTwister" ? "Word to guess" : "Definition";
                Console.WriteLine($"Game type: {scoreParts[0]}, Attempts: {scoreParts[1]}/{scoreParts[2]}, {details}: {scoreParts[3]}");
            }

        }
        else
        {
            Console.WriteLine("You have no previous scores");
        }
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }

}