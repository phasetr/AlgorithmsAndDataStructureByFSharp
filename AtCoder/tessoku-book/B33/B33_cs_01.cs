// https://atcoder.jp/contests/tessoku-book/submissions/37220534
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
        var c = NList;
        var n = c[0];
        var xor = 0;
        for (var i = 0; i < n; ++i)
        {
            c = NList;
            xor ^= (c[0] - 1) ^ (c[1] - 1);
        }
        WriteLine(xor == 0 ? "Second" : "First");
    }
}
