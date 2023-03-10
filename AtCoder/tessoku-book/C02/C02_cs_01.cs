// https://atcoder.jp/contests/tessoku-book/submissions/37635840
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
        Array.Sort(a);
        WriteLine(a[n - 2] + a[n - 1]);
    }
}
