public class Reflection : Activity {
    List<string> _listPrompts   = new List<string>();
    List<string> _listQuestions = new List<string>();

    public Reflection() : base() 
    {
        SetActivityType("Reflecting Activity");

        string p1 = "Think of a time when you stood up for someone else.";
        string p2 = "Think of a time when you did something really difficult.";
        string p3 = "Think of a time when you helped someone in need.";
        string p4 = "Think of a time when you did something truly selfless.";

        string q1 = "Why was this experience meaningful to you?";
        string q2 = "Have you ever done anything like this before?";
        string q3 = "How did you get started?";
        string q4 = "How did you feel when it was complete?";
        string q5 = "What made this time different than other times when you were not as successful?";
        string q6 = "What is your favorite thing about this experience?";
        string q7 = "What could you learn from this experience that applies to other situations?";
        string q8 = "What did you learn about yourself through this experience?";
        string q9 = "How can you keep this experience in mind in the future?";

        _listPrompts.Add(p1);
        _listPrompts.Add(p2);
        _listPrompts.Add(p3);
        _listPrompts.Add(p4);
        
        _listQuestions.Add(q1);
        _listQuestions.Add(q2);
        _listQuestions.Add(q3);
        _listQuestions.Add(q4);
        _listQuestions.Add(q5);
        _listQuestions.Add(q6);
        _listQuestions.Add(q7);
        _listQuestions.Add(q8);
        _listQuestions.Add(q9);
    }

    public override void ExplainActivity()
    {
        string message = "Welcome to the Reflecting Activity.\n\n" + 
        "This activity will help you reflect on times in your life when you\n" +
        "have shown strength and resilience. This will help you recognize\n" +
        "the power you have and how you can use it on other aspects in\n" +
        "your life.\n\n";

        Console.WriteLine(message);
    }

    public override void RunActivity()
    {
        string text = "Consider the following prompt\n\n --- ";
        text += GetRandomElement( _listPrompts );
        text += " ---\n\nWhen you have something in mind, press Enter to continue.";
        Console.WriteLine(text);
        string _ = Console.ReadLine();

        text  = "Now ponder on each of the following questions as they relate to this experience\n";
        text += "You may begin in: ";
        Console.Write(text);
        Showtimer(5);
        Console.Clear();

        StartTime();
        for (int i = 0; i < _listQuestions.Count; i++){
            text = "> " + GetRandomElement( _listQuestions ) + " ";
            Console.Write(text);
            ShowSpinner(12);

            if ( HasUsedAllSeconds() ){
                break;
            }            
        }

        Console.WriteLine("");

    }
}