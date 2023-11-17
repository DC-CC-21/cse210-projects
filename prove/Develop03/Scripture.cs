public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string word in text.Split(" "))
        {
            _words.Add(new(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new();
        for (int i = 0; i < numberToHide; i++)
        {
            List<Word> filteredWords = _words.Where(x => !x.IsHidden()).ToList();
            if (filteredWords.Count > 0)
            {
                int index = random.Next(filteredWords.Count);
                filteredWords[index].Hide();
            }

        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(' ', _words.Select(x => x.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }
    public bool IsCompletelyHidden()
    {
        List<Word> visibleWords = _words.Where(x => !x.IsHidden()).ToList();
        return visibleWords.Count == 0;
    }
}