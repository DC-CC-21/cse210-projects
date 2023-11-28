using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new(10, "blue");
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new(10, 5, "red");
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Circle circle = new(3, "pink");
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new(){
            new Square(15, "orange"),
            new Rectangle(2, 3, "black"),
            new Circle(8, "yellow"),
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}