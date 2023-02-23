// https://atcoder.jp/contests/tessoku-book/submissions/37273147
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
        var counts = new long[100];
        foreach (var ai in a) ++counts[ai % 100];
        var res = 0L;
        for (var i = 1; i < 50; ++i) res += counts[i] * counts[100 - i];
        res += counts[0] * (counts[0] - 1) / 2;
        res += counts[50] * (counts[50] - 1) / 2;
        WriteLine(res);
    }
}
