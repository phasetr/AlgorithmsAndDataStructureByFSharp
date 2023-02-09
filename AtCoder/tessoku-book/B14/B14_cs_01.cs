// https://atcoder.jp/contests/tessoku-book/submissions/35778740
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var k = int.Parse(line[1]);
        line = Console.ReadLine().Trim().Split(' ');
        var n1 = n / 2;
        var n2 = n - n1;
        var a = new int[n1];
        var b = new int[n2];
        for (int i = 0; i < n1; i++) a[i] = int.Parse(line[i]);
        for (int i = 0; i < n2; i++) b[i] = int.Parse(line[i + n1]);
        getAns(n1, a, n2, b, k);
    }
    static HashSet<int> calc(int n, int[] a)
    {
        var hs = new HashSet<int>();
        var imax = 1 << n;
        for (int i = 0; i < imax; i++)
        {
            var w = 0;
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) == 1) w += a[j];
            }
            hs.Add(w);
        }
        return hs;
    }

    static void getAns(int n1, int[] a, int n2, int[] b, int k)
    {
        var hs1 = calc(n1, a);
        var hs2 = calc(n2, b);
        foreach (var x in hs1)
        {
            if (hs2.Contains(k - x)) { Console.WriteLine("Yes"); return; }
        }
        Console.WriteLine("No");
    }
}
