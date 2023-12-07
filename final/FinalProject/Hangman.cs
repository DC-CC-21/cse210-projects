
using System.Text.RegularExpressions;

class Hangman : Game
{
    private string _hiddenWord;
    private Word _word;
    private string _guessed;
    private List<string> _asciiArt = new() { };
    public Hangman() { }
    public override void Start() { }
    protected override void Run() { }
    private void ShowHangman() { }
    private static string FormatWord(string word)
    {
        return "";
    }
    protected override void DisplayEndingMessage() { }
    public override string GetStringRepresentation()
    {
        return "";
    }

}