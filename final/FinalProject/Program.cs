using System;


class Program
{

    static void Main(string[] args)
    {
        // WordDictionary WordDictionary = new();
        // WordDictionary.LoadWords();

        // WordTwister wordTwister = new(WordDictionary);
        // wordTwister.Start();

        // Hangman hangman = new(WordDictionary);
        // hangman.Start();
        GameManager gameManager = new();
        gameManager.Start();
    }
}