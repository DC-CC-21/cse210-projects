using System.IO;

class WordDictionary
{
    public WordDictionary()
    {
        LoadWords();
    }

    private List<string> _words = new();
    private List<string> _defs = new();

    private void LoadWords()
    {
        using (StreamReader streamReader = new("words_plus_defs.txt"))
        {
            while (!streamReader.EndOfStream)
            {

                string[] wordsPlusDefs = streamReader.ReadLine().Split(": ");
                if (wordsPlusDefs[1] != "False" && wordsPlusDefs[1] != "")
                {
                    _words.Add(wordsPlusDefs[0]);
                    _defs.Add(wordsPlusDefs[1]);
                }
            }
        }
    }
    public string GetRandomWord()
    {
        Random random = new();
        int index = random.Next(_words.Count);
        return _words[index];
    }
    public string GetRandomDefinition()
    {
        Random random = new();
        int index = random.Next(_defs.Count);
        return _defs[index];
    }
    public string GetDefinition(string word)
    {
        int index = _words.IndexOf(word);
        if (index >= 0)
        {
            return _defs[index];
        }
        return "No definition found.";
    }
    public string GetWord(string definition)
    {
        int index = _defs.IndexOf(definition);
        if (index >= 0)
        {
            return _words[index];
        }
        return "No word found.";
    }
}