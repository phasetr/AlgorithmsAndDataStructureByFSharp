// https://atcoder.jp/contests/tessoku-book/submissions/37620780
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static string[] SList(long n) => Enumerable.Repeat(0, (int)n).Select(_ => ReadLine()).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (h, w, k) = (c[0], c[1], c[2]);
        var map = SList(h);
        var white = map.Select(s => s.Count(si => si == '.')).ToArray();
        var black = h * w - white.Sum();
        var bitmax = 1 << h;
        var ans = 0;
        for (var b = 0; b < bitmax; ++b)
        {
            var tmp = b;
            var list = new int[w];
            var count = k;
            var sub = 0;
            for (var i = 0; i < h; ++i)
            {
                if (tmp % 2 == 0)
                {
                    sub += white[i];
                    --count;
                }
                else
                {
                    for (var j = 0; j < w; ++j) if (map[i][j] == '.') ++list[j];
                }
                tmp >>= 1;
            }
            Array.Sort(list, (l, r) => r.CompareTo(l));
            if (count < 0) continue;
            for (var i = 0; i < count; ++i) sub += list[i];
            ans = Math.Max(ans, sub + black);
        }
        WriteLine(ans);
    }
}
