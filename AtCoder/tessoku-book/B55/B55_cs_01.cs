// https://atcoder.jp/contests/tessoku-book/submissions/37624049
using System;
using System.Collections.Generic;

class Set<T>
{
    List<T> ls;

    public Set()
    {
        ls = new List<T>();
    }

    public int Count { get { return ls.Count; } }

    public void Add(T item)
    {
        if (ls.Count == 0)
        {
            ls.Add(item);
        }
        else
        {
            int j = ls.BinarySearch(item);
            ls.Insert(~j, item);
        }
    }

    public void Remove(T item)
    {
        ls.Remove(item);
    }

    public T Get(int i)
    {
        return ls[i];
    }

    public int LowerBound(T item)
    {
        int s = ls.BinarySearch(item);
        s = (s >= 0) ? s : ~s;
        return (s < ls.Count) ? s : -1;
    }

    public int UpperBound(T item)
    {
        int s = ls.BinarySearch(item);
        s = (s >= 0) ? s : ~s - 1;
        return (s >= 0) ? s : -1;
    }
}

internal class Program
{
    private const int MaxNumber = 1000000001;

    struct Query
    {
        public int q;
        public int x;
    }

    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int q = int.Parse(strs[0]);

        Query[] qs = new Query[q];

        for (int i = 0; i < q; i++)
        {
            strs = Console.ReadLine().Split(' ');
            qs[i].q = int.Parse(strs[0]);
            qs[i].x = int.Parse(strs[1]);
        }

        Set<int> ls = new Set<int>();

        for (int i = 0; i < q; i++)
        {
            switch (qs[i].q)
            {
                case 1:
                    ls.Add(qs[i].x);
                    break;
                default:
                    int diff = -1;
                    if (ls.Count > 0)
                    {
                        int lb = ls.LowerBound(qs[i].x);
                        int ub = ls.UpperBound(qs[i].x);
                        int dl = (lb >= 0) ? ls.Get(lb) - qs[i].x : MaxNumber;
                        int du = (ub >= 0) ? qs[i].x - ls.Get(ub) : MaxNumber;
                        diff = Math.Min(dl, du);
                    }
                    Console.WriteLine(diff);
                    break;
            }
        }
    }
}
