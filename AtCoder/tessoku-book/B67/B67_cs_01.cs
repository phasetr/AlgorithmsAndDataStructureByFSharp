// https://atcoder.jp/contests/tessoku-book/submissions/38126923
using System;
using System.Collections.Generic;

public struct Edge : IComparable<Edge>
{
    public int a;
    public int b;
    public int c;

    public int CompareTo(Edge x)
    {
        return x.c - c;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);
        int m = int.Parse(strs[1]);

        int[] prts = new int[n + 1];
        int[] nums = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            prts[i] = i;
            nums[i] = 1;
        }

        Edge[] edges = new Edge[m];

        for (int i = 0; i < m; i++)
        {
            strs = Console.ReadLine().Split(' ');
            edges[i].a = int.Parse(strs[0]);
            edges[i].b = int.Parse(strs[1]);
            edges[i].c = int.Parse(strs[2]);
        }

        Array.Sort(edges);

        int ttl = 0;
        int cnt = 1;
        foreach (Edge eg in edges)
        {
            if (SameRoot(prts, eg.a, eg.b) == false)
            {
                Unite(prts, nums, eg.a, eg.b);
                ttl += eg.c;
                if (++cnt > n)
                {
                    break;
                }
            }
        }

        Console.WriteLine(ttl);
    }

    private static bool SameRoot(int[] prts, int a, int b)
    {
        return Root(prts, a) == Root(prts, b);
    }

    private static void Unite(int[] prts, int[] nums, int a, int b)
    {
        int ra = Root(prts, a);
        int rb = Root(prts, b);

        if (ra == rb)
        {
            return;
        }

        if (nums[ra] >= nums[rb])
        {
            prts[rb] = ra;
            nums[ra] += nums[rb];
        }
        else
        {
            prts[ra] = rb;
            nums[rb] += nums[ra];
        }
    }

    private static int Root(int[] prts, int i)
    {
        while (prts[i] != i)
        {
            i = prts[i];
        }

        return i;
    }
}
