using System;
using MyApp;

namespace UnitTestingDemo;

class Program
{
    static void Main()
    {
        var calc = new Calculator();

        Console.WriteLine("Manual Testing\n");

        Console.WriteLine(calc.Add(10, 20));
        Console.WriteLine(calc.Subtract(20, 10));
        Console.WriteLine(calc.Multiply(5, 4));
        Console.WriteLine(calc.Divide(10, 2));
    }
}