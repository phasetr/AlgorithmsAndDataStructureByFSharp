// https://atcoder.jp/contests/tessoku-book/submissions/37097306
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = int.Parse(ReadLine());
        var dp = Enumerable.Repeat(true, n + 1).ToArray();
        dp[0] = false;
        dp[1] = false;
        for (var i = 2; i < dp.Length; ++i) if (dp[i])
        {
            for (var j = i * 2; j < dp.Length; j += i) dp[j] = false;
        }
        WriteLine(string.Join("\n", dp.Select((b, i) => b ? i : 0).Where(i => i != 0)));
    }
}
