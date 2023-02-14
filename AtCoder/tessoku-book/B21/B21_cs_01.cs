// https://atcoder.jp/contests/tessoku-book/submissions/36853883
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');

        int n = int.Parse(strs[0]);

        strs = Console.ReadLine().Split(' ');
        char[] s = new char[n + 1];

        for (int i = 1; i <= n; i++)
        {
            s[i] = strs[0][i - 1];
        }

        int[,] dp = new int[n + 1, n + 1];

        for (int i = 0; i <= n; i++)
        {
            for(int j = 0; j <= n; j++)
            {
                dp[i, j] = 0;
            }
        }

        for (int i = n; i >= 1; i--)
        {
            dp[i, i] = 1;
            for (int j = i + 1; j <= n; j++)
            {
                dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);

                if (s[i] == s[j])
                {
                    dp[i, j] = Math.Max(2 + dp[i + 1, j - 1], dp[i, j]);
                }
            }
        }

        Console.WriteLine(dp[1, n]);
    }
}
