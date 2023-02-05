// https://atcoder.jp/contests/tessoku-book/submissions/38274068
using System;
using System.Collections.Generic;


internal class Program
{
    private const long Mod = 1000000007;
    private static void Main(string[] args)
    {
        const int MaxTime = 1440;

        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);
        int w = int.Parse(strs[1]);
        int l = int.Parse(strs[2]);
        int r = int.Parse(strs[3]);

        long[] xs = new long[n + 2];

        strs = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++)
        {
            xs[i] = long.Parse(strs[i - 1]);
        }
        xs[0] = 0;
        xs[n + 1] = w;

        long[] dp = new long[n + 2];
        long[] cdp = new long[n + 2];

        dp[0] = 1;
        cdp[0] = 1;

        int bgn_l = 0;
        int bgn_r = 0;

        for (int i = 1; i <= n + 1; i++)
        {
            dp[i] = 0;

            for (int j = bgn_l; j <= n + 1; j++)
            {
                if (xs[j] >= xs[i] - r)
                {
                    bgn_l = j;
                    break;
                }
            }
            long cdpl = (bgn_l > 0) ? cdp[bgn_l - 1] : 0;

            for (int j = bgn_r; j <= n + 1; j++)
            {
                if (xs[j] > xs[i] - l)
                {
                    bgn_r = j;
                    break;
                }
            }
            long cdpr = (bgn_r > 0) ? cdp[bgn_r - 1] : 0;

            dp[i] = (cdpr - cdpl + Mod) % Mod;

            cdp[i] = (cdp[i - 1] + dp[i]) % Mod;
        }

        Console.WriteLine(dp[n + 1]);
    }
}
