// https://atcoder.jp/contests/tessoku-book/submissions/37600512
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
        var n = int.Parse(ReadLine());
        var a = NList;
        var tree = new List<int>[n];
        for (var i = 0; i < tree.Length; ++i) tree[i] = new List<int>();
        for (var i = 0; i < a.Length; ++i)
        {
            tree[a[i] - 1].Add(i + 1);
        }
        var ans = new int[n];
        DFS(0, tree, ans);
        WriteLine(string.Join(" ", ans));
    }
    static void DFS(int cur, List<int>[] tree, int[] subs)
    {
        var cnt = 0;
        foreach (var next in tree[cur])
        {
            DFS(next, tree, subs);
            cnt += subs[next] + 1;
        }
        subs[cur] = cnt;
    }
}
