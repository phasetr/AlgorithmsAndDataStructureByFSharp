// https://atcoder.jp/contests/tessoku-book/submissions/37653054
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(int n) => Enumerable.Repeat(0, n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, m, k) = (c[0], c[1], c[2]);
        var map = NArr(m);

        var sc = new int[n][];
        for (var i = 0; i < sc.Length; ++i) sc[i] = new int[n];
        for (var i = 0; i < n; ++i) for (var j = i; j < n; ++j)
        {
            foreach (var link in map) if (i <= link[0] - 1 && link[1] - 1 <= j) ++sc[i][j];
        }
        var dp = new int[k][];
        for (var i = 0; i < dp.Length; ++i)
        {
            dp[i] = new int[n];
            if (i == 0)
            {
                for (var j = 0; j < n; ++j) dp[i][j] = sc[i][j];
            }
            else
            {
                for (var j = i; j < n; ++j)
                {
                    var max = 0;
                    for (var p = i - 1; p < j; ++p) max = Math.Max(max, dp[i - 1][p] + sc[p + 1][j]);
                    dp[i][j] = max;
                }
            }
        }
        WriteLine(dp[k - 1][n - 1]);
    }
}
