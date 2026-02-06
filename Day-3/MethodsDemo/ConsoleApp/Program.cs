using System;
using EmployeeDemo;
using ExtensionMethodsDemo;
using Utilities;

namespace MethodsDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeDemo();
            StudentDemo();
        }

        static void EmployeeDemo()
        {
            Employee dave = new Employee(1, "Dave", "Smith", 30);

            dave.Print();
            dave.DoubleTheAge();
            dave.Print();
        }

        static void StudentDemo()
        {
            var alice = new Student("Alice", 20);
            alice.Print();

            var bob = new Student("Bob", 22);
            bob.Print();

            var dave = new Student("Dave", 24);
            dave.Print();

            var charlie = new Student("Charlie", 26);
            charlie.Print();
        }
    }

    class Student
    {
        public static int NumberOfStudents = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
            NumberOfStudents++;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {this.Name}, Age: {this.Age} Student Count: {NumberOfStudents}");
        }
    }
}
