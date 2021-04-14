using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>();
            Queue<int> scarfs = new Queue<int>();

            List<int> sets = new List<int>();

            for (int i = 1; i <= 2; i++)
            {
                int[] dataLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (i == 1)
                {
                    foreach (int item in dataLine)
                    {
                        hats.Push(item);
                    }
                }
                else
                {
                    foreach (int item in dataLine)
                    {
                        scarfs.Enqueue(item); ;
                    }
                }
            }

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int curentHat = hats.Pop();
                int curentScarf = scarfs.Peek();

                if(curentHat == curentScarf)
                {
                    hats.Push(curentHat + 1);
                    scarfs.Dequeue();
                }

                else if (curentHat > curentScarf)
                {
                    int nextSet = curentHat + curentScarf;
                    sets.Add(nextSet);
                    scarfs.Dequeue();
                }

                /*
                if (curentHat < curentScarf)
                {


                }
                */
            }

            int mostExpensiveSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");

            Console.WriteLine(string.Join(' ', sets));

            //Console.WriteLine("Hello World!");
        }
    }
}
