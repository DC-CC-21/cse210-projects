public class ConsoleOptions
{
    private int _selection = 0;
    private ConsoleKey _key;
    private string _selectedOption;

    public void DisplayOptions(List<string> options, string message)
    {
        Console.CursorVisible = false;
        _selection = 0;
        do
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("Use the up and down arrow keys to choose option. Use the ESC key to return to home.");

            int index = 0;
            foreach (string value in options)
            {
                if (_selection == index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {value}");
                }
                else
                {
                    Console.WriteLine(value);

                }
                Console.ResetColor();
                index += 1;
            }

            ChooseKey(options.Count);

            Console.ResetColor();
            if (_selection == -1)
            {
                break;
            }


        } while (_key != ConsoleKey.Enter);
        SetOption(options);
        Console.CursorVisible = true;
    }
    public string ReadLineWithEscape(string msg)
    {
        Console.Clear();
        Console.WriteLine(msg);
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        string input = null;
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            Console.Clear();
            Console.WriteLine(msg);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                input = null;
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && input.Length != 0)
            {
                input = input.TrimEnd(input[input.Length - 1]);
            }
            else
            {
                input += keyInfo.KeyChar;
            }
            Console.Write(input);
            keyInfo = Console.ReadKey(true);
        }
        Console.WriteLine();
        return input;
    }
    private void SetOption(List<string> options)
    {
        if (_selection != -1)
        {
            _selectedOption = options[_selection];
        }
        else
        {
            _selectedOption = "";
        }
    }
    public string GetOption()
    {
        return _selectedOption;
    }
    public int GetOptionIndex()
    {
        return _selection;
    }
    private void ChooseKey(int listLength)
    {
        _key = Console.ReadKey(true).Key;
        switch (_key)
        {
            case ConsoleKey.DownArrow:
                if (_selection < listLength-1)
                {
                    _selection += 1;
                }
                break;
            case ConsoleKey.UpArrow:
                if (_selection > 0)
                {
                    _selection -= 1;
                }
                break;
            case ConsoleKey.Escape:
                _selection = -1;
                break;
        }
    }
}