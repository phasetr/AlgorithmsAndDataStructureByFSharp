// https://atcoder.jp/contests/tessoku-book/submissions/37019046
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().TrimStart().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = int.Parse(ReadLine());
        var h = NList;
        var dp = new int[n];
        for (var i = 1; i < n; ++i)
        {
            dp[i] = dp[i - 1] + Math.Abs(h[i] - h[i - 1]);
            if (i > 1) dp[i] = Math.Min(dp[i], dp[i - 2] + Math.Abs(h[i] - h[i - 2]));
        }
        WriteLine(dp[n - 1]);
    }
}
