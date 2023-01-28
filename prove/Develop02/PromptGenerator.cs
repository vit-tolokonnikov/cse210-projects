public class PromptGenerator
{
    public string _lastPrompt = " ";

    public List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };


    public void DisplayPrompt()
    {
        var random = new Random();
        int index = random.Next(this.prompts.Count);
        this._lastPrompt = prompts[index];
        Console.WriteLine(this._lastPrompt);
    }

    public string GetLastPrompt()
    {
        return this._lastPrompt;
    }

}