using System.Text.RegularExpressions;
class Word
{
    private string _word;
    private string _hiddenWord;
    
    public Word(string word)
    {
        _word = word;
        _hiddenWord = Regex.Replace(word, @"\w","-"); //new('-', _word.Length);
    }
    public string GetHiddenWord()
    {
        return _hiddenWord;
    }
    public void ShowRandomLetter()
    {
        List<int> indexes = new();
        for (int i = 0; i < _word.Length; i++)
        {
            if (_hiddenWord[i] == '-')
            {
                indexes.Add(i);
            }
        }
        if (indexes.Count > 0)
        {

            Random random = new();
            int randomIndex = indexes[random.Next(indexes.Count)];
            _hiddenWord = _hiddenWord.Remove(randomIndex, 1);
            _hiddenWord = _hiddenWord.Insert(randomIndex, _word[randomIndex].ToString());
        }
    }
    public void ShowAllOfType(char letter){
        for(int i = 0; i < _word.Length; i ++){
            if(_word[i] == letter){
                _hiddenWord = _hiddenWord.Remove(i, 1);
                _hiddenWord = _hiddenWord.Insert(i, letter.ToString());
            }
        }
    }
}