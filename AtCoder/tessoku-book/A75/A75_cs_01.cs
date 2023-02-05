// https://atcoder.jp/contests/tessoku-book/submissions/37633260
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
        var n = int.Parse(ReadLine());
        var map = NArr(n);
        Array.Sort(map, (l, r) => r[1].CompareTo(l[1]));
        var dp = new int[1441];
        for (var i = 0; i < map.Length; ++i)
        {
            for (var j = 1; j < dp.Length; ++j)
            {
                if (map[i][0] <= j && j <= map[i][1])
                {
                    dp[j - map[i][0]] = Math.Max(dp[j - map[i][0]], dp[j] + 1);
                }
            }
        }
        WriteLine(dp[0]);
    }
}
