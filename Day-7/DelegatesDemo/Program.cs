using System;

namespace DelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegatesDemoApp app = new DelegatesDemoApp();
            app.Run();
        }
    }

    // Delegate for math operations
    delegate int MathOperation(int a, int b);

    // Generic delegate
    delegate void GenericTwoParameterAction<TFirst, TSecond>(TFirst a, TSecond b);

    class DelegatesDemoApp
    {
        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // ---------------- Lambda Demo ----------------
        public void LambdaExpressionDemo()
        {
            Func<int, int> f;

            f = (int x) => x * x;

            var result = f(5);

            Console.WriteLine($"Lambda result: {result}");
        }

        // ---------------- Anonymous Method Demo ----------------
        public void AnonymousMethodDemo()
        {
            MathOperation operation = delegate (int a, int b)
            {
                Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
                return a + b;
            };

            operation(5, 3);
        }

        // ---------------- Main Runner ----------------
        public void Run()
        {
            // Func delegate
            Func<int, int, int> genericOperation = Add;

            // Action delegate
            Action<string> action = PrintMessage;
            action("Hello from Action delegate!");

            // Predicate delegate
            Predicate<int> predicate = IsEven;
            int testNumber = 4;
            Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

            Console.WriteLine();

            // Lambda demo
            LambdaExpressionDemo();

            Console.WriteLine();

            // Anonymous method demo
            AnonymousMethodDemo();

            Console.WriteLine();

            // String Func demo
            Func<string, string, string> stringOperation = Concatenate;

            var x = stringOperation("Hello, ", "World!");
            Console.WriteLine($"Concatenation result: {x}");

            Console.WriteLine();

            // Multicast delegate
            genericOperation += Subtract;
            genericOperation += Multiply;
            genericOperation += Divide;

            genericOperation -= Subtract;

            var result = genericOperation(5, 3);
            Console.WriteLine($"Final result: {result}");
        }

        // ---------------- Other Methods ----------------

        public string Concatenate(string a, string b)
        {
            string result = a + b;
            Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
            return result;
        }

        public int Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine($"The product of {a} and {b} is: {a * b}");
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b != 0)
            {
                Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
                return a / b;
            }
            else
            {
                Console.WriteLine("Cannot divide by zero.");
            }

            return 0;
        }
    }
}
