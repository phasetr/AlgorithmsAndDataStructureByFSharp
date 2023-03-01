// https://atcoder.jp/contests/tessoku-book/submissions/37959686
using System;


internal class Program
{
    private const int MaxStep = 1000000;

    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);
        int l = int.Parse(strs[1]);
        int r = int.Parse(strs[2]);

        int[] xs = new int[n + 1];

        strs = Console.ReadLine().Split(' ');

        xs[0] = -1;
        for (int i = 1; i <= n; i++)
        {
            xs[i] = int.Parse(strs[i - 1]);
        }

        int[] dp = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = 0;
        }

        int siz = 1;
        while (siz < n)
        {
            siz *= 2;
        }

        int[] st = new int[siz * 2];
        for (int i = 0; i < st.Length; i++)
        {
            st[i] = MaxStep;
        }

        ReplaceNumber(st, 1, 0);
        dp[1] = 0;
        for (int i = 2; i <= n; i++)
        {
            int a = Array.BinarySearch(xs, xs[i] - r);
            a = (a < 0) ? ~a : a;
            a = (a == 0) ? 1 : a;

            int b = Array.BinarySearch(xs, xs[i] - l);
            b = (b < 0) ? ~b : b + 1;

            int m = RangeMinimum(st, a, b);
            ReplaceNumber(st, i, m + 1);
            dp[i] = m + 1;
        }

        Console.WriteLine(dp[n]);
    }

    private static void ReplaceNumber(int[] st, int pos, int x)
    {
        int i = st.Length / 2 + pos - 1;
        st[i] = x;

        while (i > 1)
        {
            i /= 2;
            st[i] = Math.Min(st[2 * i], st[2 * i + 1]);
        }
    }

    private static int RangeMinimum(int[] st, int l, int r)
    {
        return RangeMin(st, l, r, 1, st.Length / 2 + 1, 1);
    }

    private static int RangeMin(int[] st, int l, int r, int a, int b, int i)
    {
        if (l <= a && b <= r)
        {
            return st[i];
        }
        else if (b <= l || r <= a)
        {
            return MaxStep;
        }

        int m = (a + b) / 2;

        int am = RangeMin(st, l, r, a, m, i * 2);
        int mb = RangeMin(st, l, r, m, b, i * 2 + 1);

        return Math.Min(am, mb);
    }
}
