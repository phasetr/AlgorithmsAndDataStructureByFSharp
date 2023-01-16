// https://atcoder.jp/contests/tessoku-book/submissions/36113002
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
        var q = int.Parse(line[1]);
        line = Console.ReadLine().Trim().Split(' ');
        var a = Array.ConvertAll(line, x => int.Parse(x) - 1);
        getAns(n, q, a);
    }
    static void getAns(int n, int q, int[] a)
    {
        var dp = new int[n, 31];
        for (int i = 0; i < n; i++) dp[i, 0] = a[i];
        for (int j = 1; j < 31; j++)
            for (int i = 0; i < n; i++) dp[i, j] = dp[dp[i, j - 1], j - 1];
        var ans = new int[q];
        for (int i = 0; i < q; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var x = int.Parse(line[0]) - 1;
            var y = int.Parse(line[1]);
            var nx = x;
            for (int j = 0; j < 31; j++)
            {
                if (((y >> j) & 1) == 1)
                {
                    nx = dp[nx, j];
                }
            }
            ans[i] = nx + 1;
        }
        Console.WriteLine(string.Join("\n", ans));
    }
}
