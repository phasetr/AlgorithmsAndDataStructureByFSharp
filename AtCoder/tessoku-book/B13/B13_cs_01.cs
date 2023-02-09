// https://atcoder.jp/contests/tessoku-book/submissions/36929221
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
        var left = 0;
        var right = 0;
        var sum = (long)a[0];
        var res = 0L;
        while (left < n)
        {
            while (right + 1 < n && sum + a[right + 1] <= k)
            {
                ++right;
                sum += a[right];
            }
            if (sum <= k) res += right - left + 1;
            sum -= a[left];
            ++left;
        }
        WriteLine(res);
    }
}
