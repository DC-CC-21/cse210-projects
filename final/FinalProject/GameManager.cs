class GameManager : References
{
    private bool _playing = true;
    private Dictionary<string, Game> _options;
    private ConsoleOptions _consoleOptions;

    public GameManager()
    {
        _consoleOptions = new();

        _options = new(){
            {"Hangman", null},
            {"WordTwister", new WordTwister()},
            {"View Previous Scores", null},
            {"Quit Program", null}
        };

    }
    public void Start()
    {
        do
        {
            _consoleOptions.DisplayOptions(_options.Keys.ToList(), "Welcome to word games\n\nChoose a game to play");
            string chosenOption = _consoleOptions.GetOption();
            if (chosenOption == "Quit Program")
            {
                _playing = false;
            }
            else if (chosenOption == "View Previous Scores")
            {
                _dataManager.LoadData();
                _dataManager.ShowScores();
            }
            else if (_options[chosenOption] is Game)
            {
                _options[chosenOption].Start();
                string representation = _options[chosenOption].GetStringRepresentation();
                if (representation != "")
                {
                    DataManager.SaveData(representation);
                }
            }
        }
        while (_playing);
        Console.WriteLine("\nThanks for playing!");
    }
}