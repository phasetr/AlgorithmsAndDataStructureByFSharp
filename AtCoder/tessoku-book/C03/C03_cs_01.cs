// https://atcoder.jp/contests/tessoku-book/submissions/37636072
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
        var d = NN;
        var x = NN;
        var price = new int[d];
        price[0] = x;
        for (var i = 1; i < d; ++i) price[i] = price[i - 1] + NN;
        var q = NN;
        var ans = new string[q];
        for (var i = 0; i < q; ++i)
        {
            var c = NList;
            if (price[c[0] - 1] == price[c[1] - 1]) ans[i] = "Same";
            else if (price[c[0] - 1] > price[c[1] - 1]) ans[i] = c[0].ToString();
            else ans[i] = c[1].ToString();
        }
        WriteLine(string.Join("\n", ans));
    }
}
