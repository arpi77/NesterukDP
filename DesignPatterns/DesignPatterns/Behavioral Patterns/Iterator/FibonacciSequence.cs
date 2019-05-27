using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral_Patterns.Iterator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fibonacciSequence = new FibonacciSequence(10);
            foreach (var item in fibonacciSequence)
            {
                // item - fibonacci number
            }
        }
    }

    public class FibonacciSequence : IEnumerable<int>
    {
        public int NumberOfValues { get; }

        public FibonacciSequence(int numberOfValues)
        {
            NumberOfValues = numberOfValues;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int previouseTotal = 0;
            int currentTotal = 0;

            for (int i = 0; i < NumberOfValues; i++)
            {
                if (i == 0)
                {
                    currentTotal = 1;
                }
                else
                {
                    int newTotal = previouseTotal + currentTotal;

                    previouseTotal = currentTotal;
                    currentTotal = newTotal;
                }

                yield return currentTotal;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
