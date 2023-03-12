// https://atcoder.jp/contests/tessoku-book/submissions/38280645
using System;
using System.Collections.Generic;

internal class Program
{

    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);

        int[] ais = new int[n + 1];
        strs = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++)
        {
            ais[i] = int.Parse(strs[i - 1]);
        }

        long[] dp = new long[n + 1];
        dp[0] = 0;
        dp[1] = ais[1];
        for (int i = 2; i <= n; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + ais[i], dp[i - 1]);
        }

        Console.WriteLine(Math.Max(dp[n - 1], dp[n]));
    }
}
