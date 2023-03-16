// https://atcoder.jp/contests/tessoku-book/submissions/37677739
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
        WriteLine(Flight(n, m, k, map));
    }
    static int Flight(int n, int m, int k, int[][] map)
    {
        var ev = new List<(int time, int kind, int id)>();
        for (var i = 0; i < map.Length; ++i)
        {
            ev.Add((map[i][1], 1, i));
            ev.Add((map[i][3] + k, 2, i));
        }
        ev.Sort((l, r) =>
        {
            var d = l.time.CompareTo(r.time);
            if (d != 0) return d;
            return r.kind.CompareTo(l.kind);
        });
        var startdpi = new int[m];
        var dp = new int[n];
        foreach (var e in ev)
        {
            if (e.kind == 1)
            {
                startdpi[e.id] = dp[map[e.id][0] - 1];
            }
            else
            {
                dp[map[e.id][2] - 1] = Math.Max(dp[map[e.id][2] - 1], startdpi[e.id] + 1);
            }
        }
        return dp.Max();
    }
}
