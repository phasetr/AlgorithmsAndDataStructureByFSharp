// https://atcoder.jp/contests/tessoku-book/submissions/37648103
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
        var (n, k) = (c[0], c[1]);
        var a = NList;
        var ok = 1_000_000_000.0;
        var ng = 1.0;
        while (ok - ng > 0.000_000_1)
        {
            var mid = (ok + ng) / 2;
            var cnt = 0L;
            for (var i = 0; i < n; ++i)
            {
                cnt += (int)(a[i] / mid);
            }
            if (cnt <= k) ok = mid;
            else ng = mid;
        }
        var ans = new int[n];
        for (var i = 0; i < n; ++i) ans[i] = (int)(a[i] / ok);
        WriteLine(string.Join(" ", ans));
    }
}
