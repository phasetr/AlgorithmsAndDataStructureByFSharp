// https://atcoder.jp/contests/tessoku-book/submissions/37045464
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().TrimStart().Split().Select(int.Parse).ToArray();
    static int[][] NArr(int n) => Enumerable.Repeat(0, n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, w) = (c[0], c[1]);
        var map = NArr(n);
        var INF = long.MaxValue / 2;
        var dp = Enumerable.Repeat(INF, 100001).ToArray();
        dp[0] = 0;
        for (var i = 0; i < n; ++i)
        {
            for (var j = dp.Length - 1 - map[i][1]; j >= 0; --j)
            {
                dp[j + map[i][1]] = Math.Min(dp[j + map[i][1]], dp[j] + map[i][0]);
            }
        }
        var res = 0;
        for (var i = 0; i < dp.Length; ++i) if (dp[i] <= w) res = i;
        WriteLine(res);
    }
}
