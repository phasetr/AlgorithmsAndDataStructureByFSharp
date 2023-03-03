// https://atcoder.jp/contests/tessoku-book/submissions/37585954
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(int n) => Enumerable.Repeat(0, n).Select(_ => NList).ToArray();
    static string[] SList(int n) => Enumerable.Repeat(0, n).Select(_ => ReadLine()).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (h, w) = (c[0], c[1]);
        c = NList;
        var (sx, sy) = (c[0], c[1]);
        c = NList;
        var (gx, gy) = (c[0], c[1]);
        var map = SList(h);
        var INF = int.MaxValue;
        var len = new int[h][];
        for (var i = 0; i < len.Length; ++i) len[i] = Enumerable.Repeat(INF, w).ToArray();
        len[sx - 1][sy - 1] = 0;
        var q = new Queue<(int x, int y, int len)>();
        q.Enqueue((sx - 1, sy - 1, 0));
        var move = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (cur.len != len[cur.x][cur.y]) continue;
            foreach (var m in move)
            {
                var nx = cur.x + m[0];
                var ny = cur.y + m[1];
                if (map[nx][ny] == '#') continue;
                if (len[nx][ny] <= cur.len + 1) continue;
                len[nx][ny] = cur.len + 1;
                q.Enqueue((nx, ny, len[nx][ny]));
            }
        }
        WriteLine(len[gx - 1][gy - 1]);
    }
}
