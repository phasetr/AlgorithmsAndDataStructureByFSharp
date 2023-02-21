// https://atcoder.jp/contests/tessoku-book/submissions/37006443
using System;

internal class Program
{
    private const int Mod = 1000000007;
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);
        int h = int.Parse(strs[1]);
        int w = int.Parse(strs[2]);

        int[] a = new int[n + 1];
        int[] b = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            strs = Console.ReadLine().Split(' ');
            a[i] = int.Parse(strs[0]);
            b[i] = int.Parse(strs[1]);
        }

        int nim = 0;
        for (int i = 1; i <= n; i++)
        {
            nim ^= (a[i] - 1) ^ (b[i] - 1);
        }

        Console.WriteLine((nim != 0) ? "First" : "Second");
    }
}
