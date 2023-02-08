// https://atcoder.jp/contests/tessoku-book/submissions/36916813
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
        var n = int.Parse(ReadLine());
        var cum = new int[1501, 1501];
        for (var i = 0; i < n; ++i)
        {
            var c = NList;
            ++cum[c[0], c[1]];
        }
        for (var i = 0; i <= 1500; ++i) for (var j = 0; j < 1500; ++j) cum[i, j + 1] += cum[i, j];
        for (var j = 0; j <= 1500; ++j) for (var i = 0; i < 1500; ++i) cum[i + 1, j] += cum[i, j];
        var q = int.Parse(ReadLine());
        var res = new long[q];
        for (var i = 0; i < q; ++i)
        {
            var c = NList;
            res[i] = cum[c[2], c[3]] - cum[c[0] - 1, c[3]] - cum[c[2], c[1] - 1] + cum[c[0] - 1, c[1] - 1];
        }
        WriteLine(string.Join("\n", res));
    }
}
