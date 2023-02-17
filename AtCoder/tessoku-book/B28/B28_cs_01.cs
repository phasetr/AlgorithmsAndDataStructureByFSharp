// https://atcoder.jp/contests/tessoku-book/submissions/35780505
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine().Trim());
        getAns(n);
    }
    static void getAns(int n)
    {
        var MOD = 1000000007;
        var pre1 = 1L;
        var pre2 = 1L;
        var ans = 0L;
        for (int i = 3; i <= n; i++)
        {
            ans = (pre1 + pre2) % MOD;
            pre2 = pre1;
            pre1 = ans;
        }
        Console.WriteLine(ans);
    }
}
