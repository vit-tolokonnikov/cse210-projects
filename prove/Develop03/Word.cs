public class Word
{
    private string _text;

    public Word(string text)
    {
        _text = text;
    }

    public string Hide()
    {
        char[] charArray = _text.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            charArray[i] = '_';
        }

        string hiddenString = new string(charArray);
        
        return hiddenString;
    }

}