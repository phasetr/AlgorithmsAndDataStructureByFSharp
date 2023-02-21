// https://atcoder.jp/contests/tessoku-book/submissions/37221239
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static long[] NList => ReadLine().Split().Select(long.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = ReadLine();
        var a = NList;
        var xor = 0L;
        for (var i = 0; i < a.Length; ++i)
        {
            var gr = a[i] % 5 / 2;
            xor ^= gr;
        }
        WriteLine(xor == 0 ? "Second" : "First");
    }
}
