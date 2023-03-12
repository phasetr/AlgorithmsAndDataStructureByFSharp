// https://atcoder.jp/contests/tessoku-book/submissions/37647167
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int NN => int.Parse(ReadLine());
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static string[] SList(int n) => Enumerable.Repeat(0, n).Select(_ => ReadLine()).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = NN;
        var map = SList(n);
        var ans = -1;
        for (var i = 0; i < 10000; ++i)
        {
            var flg = true;
            var num = i.ToString("0000");
            for (var j = 0; j < n; ++j)
            {
                var diff = 0;
                for (var c = 0; c < 4; ++c)
                {
                    if (map[j][c] != num[c]) ++diff;
                }
                if (diff == 0)
                {
                    if (map[j][5] != '1') flg = false;
                }
                else if (diff == 1)
                {
                    if (map[j][5] != '2') flg = false;
                }
                else
                {
                    if (map[j][5] != '3') flg = false;
                }
                if (!flg) break;
            }
            if (flg)
            {
                if (ans != -1)
                {
                    WriteLine("Can't Solve");
                    return;
                }
                ans = i;
            }
        }
        WriteLine(ans == -1 ? "Can't Solve" : ans.ToString("0000"));
    }
}
