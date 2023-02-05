// https://atcoder.jp/contests/tessoku-book/submissions/36884253
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
        for (var i = 0; i < n; ++i) for (var j = i + 1; j < n; ++j) for (var k = j + 1; k < n; ++k)
        {
            if (a[i] + a[j] + a[k] == 1000)
            {
                WriteLine("Yes");
                return;
            }
        }
        WriteLine("No");
    }
}
