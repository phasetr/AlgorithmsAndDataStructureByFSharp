// https://atcoder.jp/contests/tessoku-book/submissions/37585778
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
        var (n, m) = (c[0], c[1]);
        var map = NArr(m);
        var tree = new List<int>[n];
        for (var i = 0; i < tree.Length; ++i) tree[i] = new List<int>();
        foreach (var edge in map)
        {
            tree[edge[0] - 1].Add(edge[1] - 1);
            tree[edge[1] - 1].Add(edge[0] - 1);
        }
        var visited = new bool[n];
        var path = new List<int>();
        path.Add(1);
        DFS(0, n - 1, tree, visited, path);
        WriteLine(string.Join(" ", path));
    }
    static bool DFS(int cur, int goal, List<int>[] tree, bool[] visited, List<int> path)
    {
        visited[cur] = true;
        if (cur == goal) return true;
        foreach (var next in tree[cur])
        {
            if (visited[next]) continue;
            path.Add(next + 1);
            if (DFS(next, goal, tree, visited, path))
            {
                return true;
            }
            path.RemoveAt(path.Count - 1);
        }
        return false;
    }
}
