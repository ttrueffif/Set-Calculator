using System;
using SetCalculator.Sets;
using System.Linq;

namespace SetCalculator.Main
{
    internal static class App
    {
        public static void Start()
        {
            Set<int> set1 = new Set<int>('A', 99, 1, 2, 3, 8);
            Set<int> set2 = new Set<int>('B', 1, 12, 34, 2, 66, 77, 8, 3);

            Set<int> result = set2 ^ set1;

            Console.WriteLine(result);
        }
    }
}
