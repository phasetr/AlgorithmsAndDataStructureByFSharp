// https://atcoder.jp/contests/tessoku-book/submissions/37618018
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(long n) => Enumerable.Repeat(0, (int)n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, m) = (c[0], c[1]);
        var a = NList;
        var map = NArr(m);
        var bitmax = 1 << n;
        var init = 0;
        for (var i = 0; i < a.Length; ++i) if (a[i] == 1) init += 1 << i;
        var INF = int.MaxValue / 2;
        var dp = Enumerable.Repeat(INF, bitmax).ToArray();
        dp[init] = 0;
        for (var i = 0; i < m; ++i)
        {
            var next = (int[]) dp.Clone();
            for (var b = 0; b < dp.Length; ++b)
            {
                var nb = b ^ (1 << map[i][0] - 1) ^ (1 << map[i][1] - 1) ^ (1 << map[i][2] - 1);
                next[nb] = Math.Min(next[nb], dp[b] + 1);
            }
            dp = next;
        }
        WriteLine(dp.Last() == INF ? -1 : dp.Last());
    }
}
