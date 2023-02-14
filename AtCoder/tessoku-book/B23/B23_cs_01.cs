// https://atcoder.jp/contests/tessoku-book/submissions/37080895
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
        var n = int.Parse(ReadLine());
        var map = NArr(n);
        var bitmax = 1 << n;
        var INF = double.MaxValue / 2;
        var dp = new double[bitmax][];
        for (var i = 0; i < dp.Length; ++i) dp[i] = Enumerable.Repeat(INF, n).ToArray();
        dp[1][0] = 0;
        for (var b = 1; b < bitmax; ++b)
        {
            for (var s = 0; s < n; ++s)
            {
                if ((b & (1 << s)) == 0) continue;
                for (var t = 0; t < n; ++t)
                {
                    if ((b & (1 << t)) != 0) continue;
                    dp[b | (1 << t)][t] = Math.Min(dp[b | (1 << t)][t], dp[b][s] + Len(map, s, t));
                }
            }
        }
        var res = INF;
        for (var i = 0; i < n; ++i) res = Math.Min(res, dp[dp.Length - 1][i] + Len(map, i, 0));
        WriteLine(res);
    }
    static double Len(int[][] map, int i, int j)
    {
        return Math.Sqrt((map[i][0] - map[j][0]) * (map[i][0] - map[j][0]) + (map[i][1] - map[j][1]) * (map[i][1] - map[j][1]));
    }
}
