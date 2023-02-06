// https://atcoder.jp/contests/tessoku-book/submissions/35769037
using System;

public class hello
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine().Trim());
        var n = int.Parse(Console.ReadLine().Trim());
        getAns(t, n);
    }
    static void getAns(int t, int n)
    {
        var a = new long[t];
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var L = int.Parse(line[0]);
            var r = int.Parse(line[1]);
            a[L]++;
            if (r < t) a[r]--;
        }
        for (int i = 1; i < t; i++) a[i] += a[i - 1];
        Console.WriteLine(string.Join("\n", a));
    }
}
