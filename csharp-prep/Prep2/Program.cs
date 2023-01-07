using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percent? ");
        int grade = int.Parse(Console.ReadLine());
        string letter = " ";

        if (grade >= 90)
        {
            letter = "A";
            // Console.Write("A");
        }  
        else if (grade >= 80)
        {
            letter = "B";
            // Console.Write("B");
        }   
        else if (grade >= 70)
        {
            letter = "C";
            // Console.Write("C");
        }
        else if (grade >= 60)
        {
            letter = "D";
            // Console.Write("D");
        }
        else
        {
            letter = "F";
            // Console.Write("F");
        }
        
        string sign = " ";

        int last_digit = grade % 10;

        if (last_digit >= 7)
        {
            sign = "+";
        }
        else if (last_digit < 3) 
        {
            sign = "-";
        }
        else 
        {
            sign = " ";
        }
        
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Stay focused and you'll get it next time!");
        }
    }
}