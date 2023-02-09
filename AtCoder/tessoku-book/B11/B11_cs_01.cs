// https://atcoder.jp/contests/tessoku-book/submissions/36928944
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int NN => int.Parse(ReadLine());
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = NN;
        var a = NList;
        var q = NN;
        Array.Sort(a);
        var res = new int[q];
        for (var i = 0; i < q; ++i)
        {
            var x = NN;
            res[i] = LowerBound(0, x, a);
        }
        WriteLine(string.Join("\n", res));
    }
    static int LowerBound(int left, int min, int[] list)
    {
        if (list[left] >= min) return left;
        var ng = left;
        var ok = list.Length;
        while (ok - ng > 1)
        {
            var center = (ng + ok) / 2;
            if (list[center] < min) ng = center;
            else ok = center;
        }
        return ok;
    }
}
