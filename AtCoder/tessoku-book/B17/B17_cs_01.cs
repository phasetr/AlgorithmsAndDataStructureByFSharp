// https://atcoder.jp/contests/tessoku-book/submissions/36783266
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);

        strs = Console.ReadLine().Split(' ');
        int[] h = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            h[i] = int.Parse(strs[i - 1]);
        }

        int[] s = new int[n + 1];

        s[1] = 0;
        s[2] = Math.Abs(h[2] - h[1]);
        for (int i = 3; i <= n; i++)
        {
            s[i] = Math.Min(s[i - 1] + Math.Abs(h[i] - h[i - 1]), s[i - 2] + Math.Abs(h[i] - h[i - 2]));
        }

        int[] d = new int[n + 1];

        int cnt = 0;
        for(int i = n; i >= 2; i--)
        {
            d[cnt++] = i;
            if (s[i] < s[i - 1] + Math.Abs(h[i] - h[i - 1]))
            {
                i--;
            }
        }

        int[] p = new int[cnt + 1];
        p[0] = 1;
        for(int i = 1; i <= cnt; i++)
        {
            p[i] = d[cnt - i];
        }

        string str = String.Join(" ", p);

        Console.WriteLine(cnt + 1);
        Console.WriteLine(str);
    }
}
