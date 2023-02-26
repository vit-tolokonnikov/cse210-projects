public class Breathing : Activity {

    public Breathing() : base()
    {
        SetActivityType("Breathing Activity");
    }
    public override void ExplainActivity()
    {
        string message = "Welcome to the Breathing Activity.\n\n" +
        "This activity will help you relax by walking your through breathing " +
        "in and out slowly. Clear your mind, and focus on your breathing.\n";

        Console.WriteLine(message);
    }

    public void BreathInOut(int seconds4in, int seconds4out)
    {
        Console.Write("Breathe in...");
        Showtimer(seconds4in);
        Console.WriteLine("");
        Console.Write("Now breathe out...");
        Showtimer(seconds4out);
        Console.WriteLine("\n");
    }

    public override void RunActivity()
    {
        int seconds4animation = GetSeconds();

        StartTime();
        Console.WriteLine("");
        for (int i = 0; i < 100; i++){
            if (i != 0){
                BreathInOut(4, 6);
            }
            else {
                BreathInOut(2, 3);
            }

            if ( HasUsedAllSeconds() ){
                break;
            }
        }
    }
}