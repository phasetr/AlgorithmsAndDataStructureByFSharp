// https://atcoder.jp/contests/tessoku-book/submissions/36393483
using System;
using System.Collections.Generic;
using System.Linq;

class A64
{
    static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
    static void Main() => Console.WriteLine(Solve());
    static object Solve()
    {
        var (n, m) = Read2();
        var es = Array.ConvertAll(new bool[m], _ => Read());

        var map = Array.ConvertAll(new bool[n + 1], _ => new List<int[]>());
        foreach (var e in es)
        {
            map[e[0]].Add(e);
            map[e[1]].Add(new[] { e[1], e[0], e[2] });
        }

        var r = Dijkstra(map, 1);
        return string.Join("\n", r[1..].Select(x => x == long.MaxValue ? -1 : x));
    }

    static long[] Dijkstra(List<int[]>[] map, int sv, int ev = -1)
    {
        var n = map.Length;
        var costs = Array.ConvertAll(new bool[n], _ => long.MaxValue);
        costs[sv] = 0;
        var q = new SortedSet<(long, int)> { (0, sv) };

        while (q.Count > 0)
        {
            var (c, v) = q.Min;
            q.Remove((c, v));
            if (v == ev) break;

            foreach (var e in map[v])
            {
                var (nv, nc) = (e[1], c + e[2]);
                if (costs[nv] <= nc) continue;
                if (costs[nv] != long.MaxValue) q.Remove((costs[nv], nv));
                q.Add((nc, nv));
                costs[nv] = nc;
            }
        }
        return costs;
    }
}
