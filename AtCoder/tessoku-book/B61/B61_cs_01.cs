// https://atcoder.jp/contests/tessoku-book/submissions/37585595
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
        var (n, m) = (c[0], c[1]);
        var map = NArr(m);
        var count = new int[n + 1];
        foreach (var edge in map)
        {
            ++count[edge[0]];
            ++count[edge[1]];
        }
        var ans = 0;
        var max = 0;
        for (var i = 1; i <= n; ++i)
        {
            if (max < count[i])
            {
                max = count[i];
                ans = i;
            }
        }
        WriteLine(ans);
    }
}
