// https://atcoder.jp/contests/tessoku-book/submissions/37256111
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
        var s = ReadLine();
        var len = Enumerable.Repeat(1, n).ToArray();
        for (var c = 0; c < n; ++c) for (var i = 0; i < s.Length; ++i)
        {
            if (s[i] == 'A') len[i + 1] = Math.Max(len[i + 1], len[i] + 1);
            else len[i] = Math.Max(len[i], len[i + 1] + 1);
        }
        WriteLine(len.Sum());
    }
}
