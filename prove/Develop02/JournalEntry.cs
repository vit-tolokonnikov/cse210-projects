public class JournalEntry
{
    public string _curEntry = "";
    public string _lastPrompt = "";


    public void CreateEntry()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        string newEntry = Console.ReadLine();

        string text = $"Date: {dateText} - Prompt: {this._lastPrompt}\n{newEntry}\n------------------\n";

        this.SetEntry(text);
    }

    public void SetEntry(string text)
    {
        this._curEntry += text;
    }

    public void SetLastPrompt(string prompt)
    {
        this._lastPrompt = prompt;
    }
}