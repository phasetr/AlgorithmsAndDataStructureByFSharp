// https://atcoder.jp/contests/tessoku-book/submissions/36929764
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int NN => int.Parse(ReadLine());
    static int[] NList => ReadLine().Trim().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = NN;
        var a = NList;
        var set = new HashSet<int>(n);
        foreach (var ai in a) set.Add(ai);
        var list = new List<int>(set);
        list.Sort();
        var dic = new Dictionary<int, int>(n);
        for (var i = 0; i < list.Count; ++i) dic[list[i]] = i + 1;
        WriteLine(string.Join(" ", a.Select(ai => dic[ai])));
    }
}
