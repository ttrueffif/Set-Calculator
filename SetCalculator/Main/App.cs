using System;
using SetCalculator.Sets;

namespace SetCalculator.Main
{
    internal static class App
    {
        public static void Start()
        {
            Set<int> set = new Set<int>('A', 1, 2, 3, 4, 5);
            Set<int> set2 = new Set<int>('B', 1, 2, 12, 4, 455);

            Set<int> result = set & set2;

            Console.WriteLine(result);

        }
    }
}
