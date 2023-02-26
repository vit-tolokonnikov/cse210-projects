public class Activity {
    private int _seconds;
    private string _activityType;
    protected Random _randGenerator = new Random();
    private TimeSpan _elapsed;
    private DateTime _start;


    public Activity() {}

    public void run()
    {
        Console.Clear();
        ExplainActivity();
        PromptSeconds();

        Console.Clear();
        DisplayGetReady();
        
        int seconds4animation = 3;
        ShowSpinner(seconds4animation);
        
        RunActivity();
        
        Conclude();
    }


    public void SetSeconds(int seconds)
    { 
        _seconds = seconds; 
    }

    public int GetSeconds()
    { 
        return _seconds; 
    }

    public void SetActivityType(string activityType)
    { 
        _activityType = activityType;
    }

    public string GetTypeOfActivity()
    { 
        return _activityType; 
    }

    public void PromptSeconds(){
        string text = "How long, in seconds, would you like for your session? ";
        Console.Write(text);
        int seconds = int.Parse( Console.ReadLine() );
        SetSeconds(seconds);
    }

    public void DisplayGetReady(){
        Console.WriteLine("Get ready...");
    }

    public void ShowAnimation(List<string> listSymbol, int seconds4animation, int miliseconds2sleep)
    {
        int miliseconds = 1000 * seconds4animation;
        int lenList     = listSymbol.Count;
        int nIterations = miliseconds / miliseconds2sleep;
        int remainder   = 0;

        for (int i = 0; i < nIterations; i++) {
            remainder = i % lenList;
            Console.Write(listSymbol[remainder]);
            Thread.Sleep(miliseconds2sleep);
            Console.Write("\b \b");
        }    
    }

     public void ShowSpinner(int seconds4animation)
     {
        List<string> listSymbol = new List<string>();
        listSymbol.Add("/");
        listSymbol.Add("-");
        listSymbol.Add("\\");
        listSymbol.Add("|");

        int miliseconds2sleep = 500;
        ShowAnimation( listSymbol, seconds4animation, miliseconds2sleep );
        Console.WriteLine("");
     }

    public void Showtimer(int seconds) 
    {
        List<string> listSymbol = new List<string>();
        
        for (int i = seconds; i >= 1; i--) {
            listSymbol.Add( i.ToString() );
        }

        int seconds4animation = seconds;
        int miliseconds2sleep = 1000;
        ShowAnimation(listSymbol, seconds4animation, miliseconds2sleep);
    }

    public void StartTime()
    {
        _start = DateTime.Now;
    }

    public bool HasUsedAllSeconds()
    {
        _elapsed = DateTime.Now - _start;
        return ( _elapsed.Seconds > _seconds );

    }

    public void Conclude()
    {
        int seconds4animation = 5;
        int seconds = GetSeconds();
        string typeOfActivity = GetTypeOfActivity();

        Console.WriteLine("Well done!!");
        ShowSpinner(seconds4animation);
        Console.WriteLine($"You have completed another {seconds} seconds of the {typeOfActivity}.");
        ShowSpinner(seconds4animation);
    }

    public int GetRandom(int maxVal){
        return _randGenerator.Next(1, maxVal);
    }

    public string GetRandomElement(List<string> listStrings){
        int randomIndex      = GetRandom( listStrings.Count );
        string randomElement = listStrings[ randomIndex ];
        listStrings.RemoveAt(randomIndex);
        return randomElement;

    }

    public virtual void ExplainActivity(){}

    public virtual void RunActivity(){}
}