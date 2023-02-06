// https://atcoder.jp/contests/tessoku-book/submissions/36916174
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = int.Parse(ReadLine());
        var a = NList;
        var q = int.Parse(ReadLine());
        var cum = new long[n + 1];
        for (var i = 0; i < n; ++i) cum[i + 1] = cum[i] + a[i];
        var res = new string[q];
        for (var i = 0; i < q; ++i)
        {
            var c = NList;
            var w = cum[c[1]] - cum[c[0] - 1];
            var l = c[1] - c[0] + 1 - w;
            if (w > l) res[i] = "win";
            else if (w == l) res[i] = "draw";
            else res[i] = "lose";
        }
        WriteLine(string.Join("\n", res));
    }
}
