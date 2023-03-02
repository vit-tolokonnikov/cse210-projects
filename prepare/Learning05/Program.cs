using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square mySquare = new Square("Blue", 4);
        shapes.Add(mySquare);

        Rectangle myRectangle = new Rectangle("Green", 3, 8);
        shapes.Add(myRectangle);

        Circle myCircle = new Circle("Yellow", 7);
        shapes.Add(myCircle);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}