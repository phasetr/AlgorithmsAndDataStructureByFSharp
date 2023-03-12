// https://atcoder.jp/contests/tessoku-book/submissions/37646301
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
        var c = NList;
        var q = NN;
        Array.Sort(c);
        var cum = new long[n + 1];
        for (var i = 0; i < n; ++i) cum[i + 1] = cum[i] + c[i];
        var ans = new int[q];
        for (var i = 0; i < q; ++i)
        {
            var x = NN;
            var ok = 0;
            var ng = n + 1;
            while (ng - ok > 1)
            {
                var mid = (ok + ng) / 2;
                if (cum[mid] <= x) ok = mid;
                else ng = mid;
            }
            ans[i] = ok;
        }
        WriteLine(string.Join("\n", ans));
    }
}
