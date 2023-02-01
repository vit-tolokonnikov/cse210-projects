using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test1 = new Fraction();
        Console.WriteLine(test1.GetDecimalValue());
        Console.WriteLine(test1.GetFractionString());

        Fraction test2 = new Fraction(5);
        Console.WriteLine(test2.GetDecimalValue());
        Console.WriteLine(test2.GetFractionString());

        Fraction test3 = new Fraction(3, 4);
        Console.WriteLine(test3.GetDecimalValue());
        Console.WriteLine(test3.GetFractionString());

        Fraction test4 = new Fraction(1, 3);
        Console.WriteLine(test4.GetDecimalValue());
        Console.WriteLine(test4.GetFractionString());
    }
}