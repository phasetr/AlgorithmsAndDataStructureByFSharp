// https://atcoder.jp/contests/tessoku-book/submissions/36929071
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
        var ok = 0.0;
        var ng = Math.Sqrt(n);
        while (ng - ok > 0.0001)
        {
            var mid = (ok + ng) / 2;
            if (mid * mid * mid + mid < n) ok = mid;
            else ng = mid;
        }
        WriteLine(ok);
    }
}
