// https://atcoder.jp/contests/tessoku-book/submissions/37289322
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
        var map = NArr(n);
        var res = new long[4];
        foreach (var card in map)
        {
            res[0] += Math.Max(0, card[0] + card[1]);
            res[1] += Math.Max(0, card[0] - card[1]);
            res[2] += Math.Max(0, -card[0] + card[1]);
            res[3] += Math.Max(0, -card[0] - card[1]);
        }
        WriteLine(res.Max());
    }
}
