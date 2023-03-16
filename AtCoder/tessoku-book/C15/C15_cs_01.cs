// https://atcoder.jp/contests/tessoku-book/submissions/37676493
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
        var k = int.Parse(ReadLine());
        var map = NArr(n);
        WriteLine(Meeting(n, k, map));
    }
    static string Meeting(int n, int k, int[][] map)
    {
        var list = map.Select((mi, id) => (id, mi[0], mi[1] + k)).ToList();
        list.Sort((l, r) =>
        {
            var d = l.Item3.CompareTo(r.Item3);
            if (d != 0) return d;
            return l.Item2.CompareTo(r.Item2);
        });
        var front = new int[172801];
        var cur = -1;
        for (var t = 1; t < front.Length; ++t)
        {
            while (cur + 1 < n && list[cur + 1].Item3 <= t) ++cur;
            front[t] = front[t - 1];
            if (cur >= 0) front[t] = Math.Max(front[t], front[list[cur].Item2] + 1);
        }
        list.Sort((l, r) =>
        {
            var d = r.Item2.CompareTo(l.Item2);
            if (d != 0) return d;
            return r.Item3.CompareTo(l.Item3);
        });
        var back = new int[172801];
        cur = -1;
        for (var t = back.Length - 2; t >= 0; --t)
        {
            while (cur + 1 < n && list[cur + 1].Item2 >= t) ++cur;
            back[t] = back[t + 1];
            if (cur >= 0) back[t] = Math.Max(back[t], back[list[cur].Item3] + 1);
        }
        var ans = new int[n];
        foreach (var li in list)
        {
            ans[li.id] = front[li.Item2] + back[li.Item3] + 1;
        }
        return string.Join("\n", ans);
    }
}
