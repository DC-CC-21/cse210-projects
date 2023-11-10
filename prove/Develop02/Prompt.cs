using System.Collections.Generic;

class Prompt
{
    private List<string> _prompts = new(){
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be? "
    };
    private readonly Random _random = new();

    public string SelectRandomPrompt(){
        int randomValue = _random.Next(_prompts.Count);
        return _prompts[randomValue];
    }

}