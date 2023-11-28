using System;

class Program
{
    static void Main(string[] args)
    {
        // test square
        Square square = new(10, "blue");
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        // test rectangle
        Rectangle rectangle = new(10, 5, "red");
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        // tesh circle
        Circle circle = new(3, "pink");
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        // add shapes to list
        List<Shape> shapes = new(){
            new Square(15, "orange"),
            new Rectangle(2, 3, "black"),
            new Circle(8, "yellow"),
        };

        // run GetColor and GetArea on shapes in the list
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}