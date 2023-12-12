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
            Console.WriteLine("Use the up and down arrow keys to choose option");

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
    private void ChooseKey(int listLength)
    {
        _key = Console.ReadKey(true).Key;
        switch (_key)
        {
            case ConsoleKey.DownArrow:
                if (_selection < listLength - 1)
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