public class Scripture
{
    private string _text;
    private List<string> _listWord;
    private string _reference;
    private bool _isCompletelyHidden;
    private List<int> _remaingIndexes = new List<int>();

    public Scripture(string text)
    {
        _text = text;
        string[] elements = text.Split(' ');

        _listWord = elements.ToList();
        _isCompletelyHidden = false;
    }

    private void HideWord()
    {
        this.UpdateRemaingIndexes();
        
        if (_remaingIndexes.Count > 0)
        {
            int index = this.GetRandomIndex();
            Word curText = new Word(_listWord[index]);

            _listWord[index] = curText.Hide();
        } else {
            _isCompletelyHidden = true;
        }
    }

    private int GetRandomIndex()
    {
        Random rnd = new Random();
        int randomNumber = rnd.Next(_remaingIndexes.Count);
        
        return _remaingIndexes[randomNumber];
    }

    private void UpdateRemaingIndexes()
    {
        List<int> numbers = new List<int>();
        for(var i = 0; i < _listWord.Count; i++)
        {
            if (!_listWord[i].Contains("_"))
            {
                numbers.Add(i);
            }
        }
        _remaingIndexes = numbers;
    }

    private string Display()
    {
        string str = String.Join(" ", _listWord);
        Console.Clear();

        return $"{_reference} {str}\n\nPress enter to continue or type 'quit' to finish:";
    }

    public void SetReference(string text)
    {
        _reference = text;
    }

    public void StartMemorize()
    {
        
        bool start = this.GetIsCompletelyHidden();

        Console.WriteLine(this.Display());
        Console.ReadLine();

        while (!start)
        {
            this.HideWord();
            this.HideWord();
            this.HideWord();
            Console.WriteLine(this.Display());
            string input = Console.ReadLine();
            
            if (input == "quit")
            {
                _isCompletelyHidden = true;
            }
            start = this.GetIsCompletelyHidden();
        }
    }

    private bool GetIsCompletelyHidden()
    {
        return _isCompletelyHidden;
    }
}
