using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            Exceeding Requirements:
                Added the ability for the user to choose if they would like to play again
                Added the ability for the program to randomly choose a scripture
                Added functionality to hide only words that have not already been hidden
                Program loads scriptures from a .txt file
        */

        ScriptureLoader scriptureLoader = new("mastery.txt");
        ConsoleOptions consoleOptions = new();

        bool playing = true;
        List<string> options = new(){
            "yes",
            "no"
        };

        while (playing)
        {

            List<string> scriptures = scriptureLoader.ChooseScripture();
            string book = scriptures[0];
            string verses = scriptures[4];
            int chapter = int.Parse(scriptures[1]);
            int verse = int.Parse(scriptures[2]);
            int endVerse = int.Parse(scriptures[3]);

            Reference reference;
            if (endVerse == -1)
            {
                reference = new(book, chapter, verse);
            }
            else
            {
                reference = new(book, chapter, verse, endVerse);
            }

            Scripture scripture = new(reference, verses);
            string input;

            while (true)
            {
                Console.Clear();
                string text = scripture.GetDisplayText();
                Console.WriteLine(text);
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
                input = Console.ReadLine();
                if (input == "quit")
                {
                    playing = false;
                    break;
                }
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }
                scripture.HideRandomWords(3);
            }
            if (!playing)
            {
                break;
            }
            consoleOptions.DisplayOptions(options, "Thanks for playing\nWould you like to play again");
            string option = consoleOptions.GetOption();
            playing = option == "yes";
        }

    }
}