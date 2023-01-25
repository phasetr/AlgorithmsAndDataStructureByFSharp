// https://atcoder.jp/contests/tessoku-book/submissions/36130386
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class P
{
    public int to { get; set; }
    public int from { get; set; }
    public int step { get; set; }
}

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var m = int.Parse(line[1]);
        getAns(n, m);
    }
    static void getAns(int n, int m)
    {
        var aa = new List<int>[n];
        for (int i = 0; i < n; i++) aa[i] = new List<int>();
        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var a = int.Parse(line[0]) - 1;
            var b = int.Parse(line[1]) - 1;
            aa[a].Add(b);
            aa[b].Add(a);
        }
        var q = new Queue<P>();
        var map = new int[n];
        for (int i = 0; i < n; i++) map[i] = -1;
        var visited = new bool[n];
        q.Enqueue(new P { from = 0, to = 0, step = 0 });
        map[0] = 0;
        visited[0] = true;
        while (q.Count > 0)
        {
            var w = q.Dequeue();
            foreach (var x in aa[w.to])
            {
                if (visited[x]) continue;
                q.Enqueue(new P { to = x, from = w.from, step = w.step + 1 });
                visited[x] = true;
                map[x] = w.step + 1;
            }
        }
        Console.WriteLine(string.Join("\n", map));
    }
}
