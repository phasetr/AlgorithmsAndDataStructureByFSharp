// https://atcoder.jp/contests/tessoku-book/submissions/36836603
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string str = Console.ReadLine();

        int ns = str.Length;
        char[] s = new char[ns + 1];
        for (int i = 1; i <= ns; i++)
        {
            s[i] = str[i - 1];
        }

        str = Console.ReadLine();

        int nt = str.Length;
        char[] t = new char[nt + 1];
        for (int i = 1; i <= nt; i++)
        {
            t[i] = str[i - 1];
        }

        int[,] dp = new int[ns + 1, nt + 1];

        for (int i = 0; i <= ns; i++)
        {
            dp[i, 0] = i;
        }

        for (int j = 0; j <= nt; j++)
        {
            dp[0, j] = j;
        }

        for (int i = 1; i <= ns; i++)
        {
            for (int j = 1; j <= nt; j++)
            {
                int cost = (s[i] == t[j]) ? 0 : 1;
                dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
            }
        }

        Console.WriteLine(dp[ns, nt]);
    }
}
