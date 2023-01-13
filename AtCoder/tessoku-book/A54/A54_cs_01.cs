// https://atcoder.jp/contests/tessoku-book/submissions/37430107
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
        var dic = new Dictionary<string, int>(n);
        var res = new List<int>();
        for (var i = 0; i < n; ++i)
        {
            var c = ReadLine().Split();
            if (c[0] == "1") dic[c[1]] = int.Parse(c[2]);
            else res.Add(dic[c[1]]);
        }
        WriteLine(string.Join("\n", res));
    }
}
