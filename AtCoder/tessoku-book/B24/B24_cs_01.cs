// https://atcoder.jp/contests/tessoku-book/submissions/37081280
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
        Array.Sort(map, (l, r) =>
        {
            var d = l[0].CompareTo(r[0]);
            if (d != 0) return d;
            return r[1].CompareTo(l[1]);
        });
        var dp = Enumerable.Repeat(int.MaxValue, n).ToArray();
        for (var i = 0; i < n; ++i)
        {
            var pos = LowerBound(0, map[i][1], dp);
            dp[pos] = map[i][1];
        }
        var res = 0;
        for (var i = 0; i < n; ++i) if (dp[i] < int.MaxValue) res = i + 1;
        WriteLine(res);
    }
    static int LowerBound(int left, int min, int[] list)
    {
        if (list[left] >= min) return left;
        var ng = left;
        var ok = list.Length;
        while (ok - ng > 1)
        {
            var center = (ng + ok) / 2;
            if (list[center] < min) ng = center;
            else ok = center;
        }
        return ok;
    }
}
