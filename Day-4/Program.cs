﻿// See https://aka.ms/new-console-template for more information
//Method poverloading
using System;

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        int intResult = calc.Add(10, 20);
        Console.WriteLine("Int Add Result: " + intResult);

        double doubleResult = calc.Add(10.5, 20.3);
        Console.WriteLine("Double Add Result: " + doubleResult);
    }
}