// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/4828537/sakapon/C%23
using System;
using System.Collections.Generic;
using System.Linq;

class D
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var d = a.OrderBy(x => x).Select((x, i) => new { x, i }).ToDictionary(_ => _.x, _ => _.i);
        var b = a.Select(x => d[x]).ToArray();

        var r = a.Sum();
        var m = a.Min();
        var u = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (u[i]) continue;

            var l = new List<int> { i };
            var t = i;
            while ((t = b[t]) != i)
            {
                l.Add(t);
                u[t] = true;
            }
            var lm = l.Min(j => a[j]);
            r += Math.Min((l.Count - 2) * lm, (l.Count + 1) * m + lm);
        }
        Console.WriteLine(r);
    }
}
