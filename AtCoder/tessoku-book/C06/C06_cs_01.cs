// https://atcoder.jp/contests/tessoku-book/submissions/37646177
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = int.Parse(ReadLine());
        WriteLine(n);
        for (var i = 0; i < n; ++i)
        {
            WriteLine($"{i + 1} {(i + 1) % n + 1}");
        }
    }
}
