using System.IO;
class ScriptureLoader
{
    private List<List<string>> _scriptures = new();
    private string _filepath;

    public ScriptureLoader(string filepath)
    {
        _filepath = filepath;
        LoadScriptures();
    }
    private void LoadScriptures()
    {
        int index = -1;
        using (StreamReader reader = new(_filepath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                index++;

                // skip headers
                if (index == 0)
                {
                    continue;
                }

                _scriptures.Add(line.Split("\t").ToList());
            }
        }
    }
    public List<string> ChooseScripture()
    {
        Random random = new();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}