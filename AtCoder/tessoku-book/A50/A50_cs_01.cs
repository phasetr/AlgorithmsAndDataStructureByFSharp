// https://atcoder.jp/contests/tessoku-book/submissions/37704848
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
        var a = NArr(100);
        var r = new Random();
        var begin = DateTime.Now;
        var ans = Init(r);
        var sc = Calc(a, ans);
        var count = 0;
        while ((DateTime.Now - begin).TotalSeconds < 5.7)
        {
            for (var i = 0; i < 100; ++i)
            {
                var pos = r.Next(1000);
                var pq = ans[pos];
                var nq = Move(r, a, sc.b, pq);
                var ns = Diff(a, sc.b, pq, nq);
                if (sc.sum < ns.sum)
                {
                    sc = ns;
                    ans[pos] = nq;
                }
                ++count;
            }
        }
        WriteLine(ans.Length);
        WriteLine(string.Join("\n", ans.Select(ai => string.Join(" ", ai))));
        // Error.WriteLine(count);
        // Error.WriteLine(sc.sum);
    }
    static int[][] Init(Random r)
    {
        var ans = new int[1000][];
        for (var i = 0; i < 1000; ++i) ans[i] = Ranq(r);
        return ans;
    }
    static int[] Ranq(Random r)
    {
        return new int[] { r.Next(100), r.Next(100), r.Next(100) + 1 };
    }
    static int[] Move(Random r, int[][] a, int[][] b, int[] prev)
    {
        var ans = new int[3];
        ans[0] = GetNext(r, prev[0], 0, 99, -3, 4);
        ans[1] = GetNext(r, prev[1], 0, 99, -3, 4);
        ans[2] = GetNext(r, prev[2], 1, 100, -5, 6);
        return ans;
    }
    static int GetNext(Random r, int cur, int min, int max, int dmin, int dmax)
    {
        while (true)
        {
            var next = cur + r.Next(dmin, dmax);
            if (min <= next && next <= max) return next;
        }
    }
    static (int sum, int[][] b) Calc(int[][] a, int[][] ans)
    {
        var sum = 200_000_000;
        var b = new int[a.Length][];
        for (var i = 0; i < b.Length; ++i)
        {
            b[i] = new int[a[i].Length];
            for (var j = 0; j < b[i].Length; ++j)
            {
                for (var k = 0; k < ans.Length; ++k)
                {
                    b[i][j] += Math.Max(0, ans[k][2] - Math.Abs(i - ans[k][1]) - Math.Abs(j - ans[k][0]));
                }
                sum -= Math.Abs(a[i][j] - b[i][j]);
            }
        }
        return (sum, b);
    }
    static (int sum, int[][] b) Diff(int[][] a, int[][] pb, int[] pq, int[] nq)
    {
        var sum = 200_000_000;
        var b = new int[pb.Length][];
        for (var i = 0; i < b.Length; ++i)
        {
            b[i] = (int[]) pb[i].Clone();
            for (var j = 0; j < b[i].Length; ++j)
            {
                b[i][j] -= Math.Max(0, pq[2] - Math.Abs(i - pq[1]) - Math.Abs(j - pq[0]));
                b[i][j] += Math.Max(0, nq[2] - Math.Abs(i - nq[1]) - Math.Abs(j - nq[0]));
                sum -= Math.Abs(a[i][j] - b[i][j]);
            }
        }
        return (sum, b);
    }
}
