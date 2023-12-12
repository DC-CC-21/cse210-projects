class WordTwister : Game
{
    private string _currentWord;
    private string _scrambledWord;

    public WordTwister()
    {
        _description = "Welcome to WordTwister.\nIn this game the object is to unscramble the letters to guess the word.\n\nPress enter to begin";
    }
    public override void Start()
    {
        _attempts = 0;
        _currentWord = "";
        _hiddenWord = new(_wordDictionary.GetRandomWord());
        _maxAttempts = _hiddenWord.Length;
        _scrambledWord = Scramble();
        DisplayStartingMessage();
        Run();
        DisplayEndingMessage();
    }
    protected override void Run()
    {
        Word hint = new(_hiddenWord);
        while (_currentWord != _hiddenWord)
        {
            Console.Clear();
            Console.WriteLine($"Unscramble the word:\n{_scrambledWord}\n\n");
            Console.Write($"Your guess (hint: {hint.GetHiddenWord()}): ");
            _currentWord = Console.ReadLine();

            if (_currentWord != _hiddenWord)
            {
                Console.Write("Incorrect");
                if (_attempts >= _hiddenWord.Length)
                {
                    break;
                }
                _attempts += 1;
                hint.ShowRandomLetter();
            }
            else
            {
                Console.Write("Correct");
            }
            Console.CursorVisible = false;
            Thread.Sleep(1000);
            Console.CursorVisible = true;
        }
        if (_attempts >= _hiddenWord.Length)
        {
            Thread.Sleep(500);
            Console.WriteLine("\nYou lose");
            Thread.Sleep(800);
        }
    }
    private string Scramble()
    {
        _scrambledWord = _hiddenWord;

        Random random = new();
        foreach (char letter in _hiddenWord)
        {
            int index = random.Next(_scrambledWord.Length);
            _scrambledWord = _scrambledWord.Remove(_scrambledWord.IndexOf(letter), 1);
            Console.WriteLine(_scrambledWord);
            _scrambledWord = _scrambledWord.Insert(index, letter.ToString());
            Console.WriteLine(_scrambledWord);
        }

        return _scrambledWord;
    }
    protected override void DisplayEndingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Congratulations you guessed the word in {_attempts} attempts!\n");
        string definition = _wordDictionary.GetDefinition(_hiddenWord);
        Console.WriteLine($"{_hiddenWord} - {definition}");

        Thread.Sleep(1200);
    }
    public override string GetStringRepresentation()
    {
        return $"WordTwister : {_attempts} : {_maxAttempts} : {_hiddenWord}";
    }
}