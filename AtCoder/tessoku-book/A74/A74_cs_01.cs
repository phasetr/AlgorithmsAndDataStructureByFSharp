// https://atcoder.jp/contests/tessoku-book/submissions/37632880
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(long n) => Enumerable.Repeat(0, (int)n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = int.Parse(ReadLine());
        var map = NArr(n);
        var hori = new int[n];
        var vert = new int[n];
        for (var i = 0; i < n; ++i) for (var j = 0; j < n; ++j)
        {
            if (map[i][j] != 0)
            {
                hori[i] = map[i][j];
                vert[j] = map[i][j];
            }
        }
        var ans = 0;
        for (var i = 0; i < n; ++i) for (var j = i + 1; j < n; ++j)
        {
            if (hori[i] > hori[j]) ++ans;
            if (vert[i] > vert[j]) ++ans;
        }
        WriteLine(ans);
    }
}
