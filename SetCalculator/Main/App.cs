using System;
using SetCalculator.Sets;
using System.Linq;

namespace SetCalculator.Main
{
    internal static class App
    {
        public static void Start()
        {
            Set<int> set1 = new Set<int>('A', 1, 2, 34, 66);
            Set<int> set2 = new Set<int>('B', 1, 12, 34, 66, 77, 8);

            Set<int> result = set1 | set2;

            Console.WriteLine(result);
        }
    }
}
