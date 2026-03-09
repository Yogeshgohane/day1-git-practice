using System;
using System.Collections;
using System.Collections.Generic;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClassesDemo();
            //ArrayCollectionDemo();
        }

        public static void CollectionClassesDemo()
        {
            // List with initial capacity = 10
            List<int> marks = new List<int>(10);

            marks.Add(1);
            marks.Add(1);
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new int[] { 1, 2, 3 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new List<int> { 4, 5, 6 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new List<int> { 4, 5, 6 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");
        }

        public static void ArrayCollectionDemo()
        {
            ArrayList list = new ArrayList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("Hello");
            list.Add(3.14);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}