// https://atcoder.jp/contests/tessoku-book/submissions/35800779
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine().Trim());
        string[] line = Console.ReadLine().Trim().Split(' ');
        var a = Array.ConvertAll(line, int.Parse);
        line = Console.ReadLine().Trim().Split(' ');
        var b = Array.ConvertAll(line, int.Parse);
        getAns(n, a, b);
    }
    static void getAns(int n, int[] a, int[] b)
    {
        Array.Sort(a);
        Array.Sort(b);
        Array.Reverse(b);
        var ans = 0;
        for (int i = 0; i < n; i++) ans += a[i] * b[i];
        Console.WriteLine(ans);
    }
}
