// https://atcoder.jp/contests/tessoku-book/submissions/37475262
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
        var c = NList;
        var (n, k) = (c[0], c[1]);
        var a = new int[n + 1];
        for (var i = 0; i < a.Length; ++i)
        {
            a[i] = i - i.ToString().Sum(d => d - '0');
        }
        var dbl = new int[30][];
        dbl[0] = a;
        for (var i = 1; i < dbl.Length; ++i)
        {
            var next = new int[n + 1];
            for (var j = 0; j < next.Length; ++j) next[j] = dbl[i - 1][dbl[i - 1][j]];
            dbl[i] = next;
        }
        var res = new int[n];
        for (var i = 0; i < n; ++i) res[i] = i + 1;
        while (k > 0)
        {
            var d = 1;
            for (var i = 0; i < dbl.Length; ++i)
            {
                if (d * 2 > k)
                {
                    for (var j = 0; j < n; ++j) res[j] = dbl[i][res[j]];
                    k -= d;
                    break;
                }
                d <<= 1;
            }
        }
        WriteLine(string.Join("\n", res));
    }
}
