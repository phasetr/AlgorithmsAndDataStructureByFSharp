// https://atcoder.jp/contests/tessoku-book/submissions/37600585
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(int n) => Enumerable.Repeat(0, n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, t) = (c[0], c[1]);
         var map = NArr(n - 1);
        var tree = new List<int>[n];
        for (var i = 0; i < tree.Length; ++i) tree[i] = new List<int>();
        foreach (var edge in map)
        {
            tree[edge[0] - 1].Add(edge[1] - 1);
            tree[edge[1] - 1].Add(edge[0] - 1);
        }
        var ans = new int[n];
        DFS(-1, t - 1, tree, ans);
        WriteLine(string.Join(" ", ans));
    }
    static void DFS(int prev, int cur, List<int>[] tree, int[] subs)
    {
        var cls = 0;
        foreach (var next in tree[cur])
        {
            if (prev == next) continue;
            DFS(cur, next, tree, subs);
            cls = Math.Max(cls, subs[next] + 1);
        }
        subs[cur] = cls;
    }
}
