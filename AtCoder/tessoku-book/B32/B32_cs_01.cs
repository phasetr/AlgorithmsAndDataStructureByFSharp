// https://atcoder.jp/contests/tessoku-book/submissions/37220218
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, k) = (c[0], c[1]);
        var a = NList;
        var dp = new bool[n + 1];
        for (var i = 1; i <= n; ++i)
        {
            for (var j = 0; j < a.Length; ++j) if (i - a[j] >= 0 && !dp[i - a[j]]) dp[i] = true;
        }
        WriteLine(dp[n] ? "First" : "Second");
    }
}
