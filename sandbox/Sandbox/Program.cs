using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello Sandbox World!");
//     }
// }
static string input(string message){
    Console.Write(message);
    return Console.ReadLine();
}


Console.Write("What is your favorite color: ");
string color = Console.ReadLine();

Console.WriteLine($"Your favorite color is {color}");

string age = input("What is your age");
Console.WriteLine($"Your age is {age}");
