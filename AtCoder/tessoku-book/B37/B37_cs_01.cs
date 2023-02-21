// https://atcoder.jp/contests/tessoku-book/submissions/37041655
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        long n = long.Parse(strs[0]);

        long m10 = 1;
        int max_p = 15;
        for(int i = 1; i <= max_p; i++)
        {
            m10 *= 10;
        }

        long ttl = 0;
        long t_d = 0;
        for(int i = max_p; i >= 0; i--)
        {
            long d = n / m10;
            n %= m10;

            if (d > 0)
            {
                for (int j = 0; j < d; j++)
                {
                    ttl += (i * m10 / 10) * 45 + 1;
                    ttl += j * m10;
                    ttl += t_d * m10;
                }
                t_d += d;
            }

            m10 /= 10;
        }

        Console.WriteLine(ttl);
    }
}
