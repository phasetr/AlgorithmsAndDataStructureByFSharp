// https://atcoder.jp/contests/tessoku-book/submissions/38181312
using System;
using System.Collections.Generic;

public class MaximumFlow
{
    int n;
    int[,] caps;
    int[] bfr;

    public MaximumFlow(int n)
    {
        this.n = n;

        caps = new int[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                caps[i, j] = 0;
            }
        }

        bfr = new int[n + 1];
    }

    public void Add(int a, int b, int c)
    {
        caps[a, b] = c;
    }

    private bool SearchPath(int s, int g)
    {
        Queue<int> srch = new Queue<int>();

        for (int i = 0; i < bfr.Length; i++)
        {
            bfr[i] = -1;
        }

        srch.Enqueue(s);

        bfr[s] = 0;

        bool rt = false;
        while (srch.Count > 0)
        {
            int i = srch.Dequeue();

            if (i == g)
            {
                rt = true;
                break;
            }

            for (int j = 1; j <= n; j++)
            {
                if (bfr[j] < 0 && caps[i, j] > 0)
                {
                    srch.Enqueue(j);
                    bfr[j] = i;
                }
            }
        }

        return rt;
    }

    private int UpdateFlow(int s, int g)
    {
        int c = 5000;
        for (int j = g; j != s;)
        {
            int i = bfr[j];
            c = Math.Min(caps[i, j], c);
            j = i;
        }

        for (int j = g; j != s;)
        {
            int i = bfr[j];

            caps[i, j] -= c;
            caps[j, i] += c;

            j = i;
        }

        return c;
    }

    public int MaxFlow(int s, int g)
    {
        int ttl = 0;

        while (SearchPath(s, g))
        {
            ttl += UpdateFlow(s, g);
        }

        return ttl;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);

        MaximumFlow fn = new MaximumFlow(2 * n + 2);

        for (int i = 1; i <= n; i++)
        {
            strs = Console.ReadLine().Split(' ');

            for (int j = 1; j <= n; j++)
            {
                if (strs[0][j - 1] == '#')
                {
                    fn.Add(i, n + j, 1);
                }
            }
        }

        int st = 2 * n + 1;
        int gl = 2 * n + 2;

        for(int i = 1; i <= n; i++)
        {
            fn.Add(st, i, 1);
            fn.Add(n + i, gl, 1);
        }

        Console.WriteLine(fn.MaxFlow(st, gl));
    }
}
