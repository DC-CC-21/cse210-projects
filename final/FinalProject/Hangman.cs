
using System.Text.RegularExpressions;

class Hangman : Game
{
    private Word _word;
    private string _guessed;
    private List<string> _asciiArt = new(){
        @"
    ___
   |   |
       |
       |
       |
_______|___",
        @"
    ___
   |   |
   O   |
       |
       |
_______|___",
        @"
    ___
   |   |
  \O   |
       |
       |
_______|___",
        @"
    ___
   |   |
  \O/  |
       |
       |
_______|___",
        @"
    ___
   |   |
  \O/  |
   |   |
       |
_______|___",
        @"
    ___
   |   |
  \O/  |
   |   |
  /    |
_______|___",
        @"
    ___
   |   |
  \O/  |
   |   |
  / \  |
_______|___"
    };
    public Hangman()
    {
        _description = "Welcome to Hangman.\nIn this game the object is to guess the words definition before you character is fully drawn. (Ignore symbols and line breaks)\n\nPress enter to begin";
    }
    public override void Start()
    {
        _hiddenWord = _wordDictionary.GetRandomDefinition();

        string word = _hiddenWord;
        word = FormatWord(word);
        _word = new(word);
        _attempts = 0;
        _guessed = "";
        _maxAttempts = _asciiArt.Count;

        DisplayStartingMessage();
        Run();
        DisplayEndingMessage();
    }
    protected override void Run()
    {
        string guess;
        string reHiddenWord = Regex.Replace(_hiddenWord, @"[^\w\s]", "");
        do
        {
            if (_attempts >= _asciiArt.Count)
            {
                break;
            }
            ShowHangman();
            Console.Write("\nYour Guess: ");
            guess = Console.ReadLine();

            if (guess.Length == 1)
            {
                _word.ShowAllOfType(char.Parse(guess));
                if (!reHiddenWord.Contains(char.Parse(guess)))
                {
                    _attempts += 1;
                }
                if (_guessed.Contains(guess))
                {
                    Console.WriteLine("You already guesses that letter");
                    Thread.Sleep(200);
                }
                else
                {
                    _guessed += guess;
                }
            }
            else if (guess != reHiddenWord)
            {
                Console.WriteLine("Incorrect");
                _attempts += 1;
                Thread.Sleep(500);
            }

        }
        while (guess != reHiddenWord);


    }
    private void ShowHangman()
    {
        Console.Clear();

        string[] hangmanParts = _asciiArt[_attempts].Split("\n");
        string[] wordParts = Regex.Replace(_word.GetHiddenWord(), @"[^\w\s-]", "").Split("\n");
        int index = -3;
        foreach (string part in hangmanParts)
        {
            if (index == -2)
            {
                string word = _wordDictionary.GetWord(_hiddenWord);
                int len = (34 - word.Length) >= 0 ? 34 - word.Length : 0;
                Console.WriteLine($"Hint word: {word}{new string(' ', len)}{part}");
            }
            else if (index == -1)
            {
                string guessed = $"You have guessed: {_guessed}";
                int len = (45 - guessed.Length) >= 0 ? 45 - guessed.Length : 0;
                Console.WriteLine($"{guessed}{new string(' ', len)}{part}");
            }
            else if (index >= 0 && index < wordParts.Length)
            {
                string wordPart = wordParts[index];
                int len = (45 - wordPart.Length) >= 0 ? 45 - wordPart.Length : 0;
                Console.WriteLine($"{wordPart}{new string(' ', 45 - wordPart.Length)}{part}");
            }
            else
            {
                Console.WriteLine($"{new string(' ', 45)}{part}");
            }
            index += 1;
        }
        for (int i = index; i < wordParts.Length; i++)
        {
            Console.WriteLine(wordParts[i]);
        }

    }
    private static string FormatWord(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (i % 45 == 0)
            {
                word = word.Insert(i, "\n");
            }
        }
        return word;
    }
    protected override void DisplayEndingMessage()
    {
        if (_attempts < _asciiArt.Count)
        {
            Console.WriteLine("Congratulations you guessed the word!");
        }
        else
        {
            Console.WriteLine("You lose");
        }
        Thread.Sleep(1000);
    }
    public override string GetStringRepresentation()
    {
        return $"Hangman : {_attempts} : {_maxAttempts} : {_hiddenWord}";
    }

}