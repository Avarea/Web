using System;
using System.Linq;
using System.Threading;

namespace EvenNumbersThread
{
    class StartUp
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = numbers[0];
            int last = numbers[1];

            Thread thread = new Thread(() => PrintEvenNumbers(first, last));
            thread.Start();
            thread.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int first, int last)
        {
            for (int i = first; i <= last; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
