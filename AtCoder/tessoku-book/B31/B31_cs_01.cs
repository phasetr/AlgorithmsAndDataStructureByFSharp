// https://atcoder.jp/contests/tessoku-book/submissions/36942421
using System;

internal class Program
{
    private const int Mod = 1000000007;
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        long n = long.Parse(strs[0]);

        long a = n / 3 + n / 5 + n / 7;

        a = a - n / (3 * 5) - n / (5 * 7) - n / (7 * 3);

        a = a + n / (3 * 5 * 7);

        Console.WriteLine(a);
    }
}
