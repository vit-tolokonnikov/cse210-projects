public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse_start;
    private int _verse_end;

    public Reference(string book, int chapter, int verse_start, int verse_end)
    {
        _book = book;
        _chapter = chapter;
        _verse_start = verse_start;
        _verse_end = verse_end;
    }

    public string ShowReference()
    {
        if (_verse_start != _verse_end)
        {
            return $"{_book} {_chapter}:{_verse_start}-{_verse_end}";
        } 
        else
        {
            return $"{_book} {_chapter}:{_verse_start}";
        }
        
    }
}