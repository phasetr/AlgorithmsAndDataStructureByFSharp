// https://atcoder.jp/contests/tessoku-book/submissions/37634799
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
        var (n, l) = (c[0], c[1]);
        var k = int.Parse(ReadLine());
        var a = NList.ToList();
        a.Add(l);
        var ok = 1;
        var ng = l + 1;
        while (ng - ok > 1)
        {
            var mid = (ok + ng) / 2;
            var prev = 0;
            var cnt = 0;
            for (var i = 0; i < a.Count; ++i)
            {
                if (a[i] - prev >= mid)
                {
                    prev = a[i];
                    ++cnt;
                }
            }
            if (cnt > k) ok = mid;
            else ng = mid;
        }
        WriteLine(ok);
    }
}
