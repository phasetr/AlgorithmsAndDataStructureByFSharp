// https://atcoder.jp/contests/tessoku-book/submissions/37620898
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    static int[][] NArr(long n) => Enumerable.Repeat(0, (int)n).Select(_ => NList).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, m) = (c[0], c[1]);
        var map = NArr(m);
        var tree = new List<(int to, long len)>[n];
        for (var i = 0; i < tree.Length; ++i) tree[i] = new List<(int to, long len)>();
        foreach (var edge in map)
        {
            tree[edge[0] - 1].Add((edge[1] - 1, edge[2] * 100000L - edge[3]));
            tree[edge[1] - 1].Add((edge[0] - 1, edge[2] * 100000L - edge[3]));
        }
        var len = Enumerable.Repeat(long.MaxValue / 2, n).ToArray();
        len[0] = 0;
        var q = new PriorityQueue<Pair>(n, false);
        q.Enqueue(new Pair(0, 0));
        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (len[cur.Pos] != cur.Val) continue;
            foreach (var next in tree[cur.Pos])
            {
                if (len[next.to] <= cur.Val + next.len) continue;
                len[next.to] = cur.Val + next.len;
                q.Enqueue(new Pair(next.to, len[next.to]));
            }
        }
        WriteLine($"{(len[n - 1] + 99999) / 100000} {(100000 - len[n - 1] % 100000) % 100000}");
    }
    class Pair : IComparable<Pair>
    {
        public int Pos;
        public long Val;
        public Pair(int pos, long val)
        {
            Pos = pos; Val = val;
        }
        public int CompareTo(Pair b)
        {
            return Val.CompareTo(b.Val);
        }
    }
    class PriorityQueue<T> where T : IComparable<T>
    {
        public T[] List;
        public int Count;
        bool IsTopMax;
        public PriorityQueue(int count, bool isTopMax)
        {
            IsTopMax = isTopMax;
            List = new T[Math.Max(128, count)];
        }
        public void Enqueue(T value)
        {
            if (Count == List.Length)
            {
                var newlist = new T[List.Length * 2];
                for (var i = 0; i < List.Length; ++i) newlist[i] = List[i];
                List = newlist;
            }
            var pos = Count;
            List[pos] = value;
            ++Count;
            while (pos > 0)
            {
                var parent = (pos - 1) / 2;
                if (Calc(List[parent], List[pos], true)) break;
                Swap(parent, pos);
                pos = parent;
            }
        }
        public T Dequeue()
        {
            --Count;
            Swap(0, Count);
            var pos = 0;
            while (true)
            {
                var child = pos * 2 + 1;
                if (child >= Count) break;
                if (child + 1 < Count && Calc(List[child + 1], List[child], false)) ++child;
                if (Calc(List[pos], List[child], true)) break;
                Swap(pos, child);
                pos = child;
            }
            return List[Count];
        }
        bool Calc(T a, T b, bool equalVal)
        {
            var ret = a.CompareTo(b);
            if (ret == 0 && equalVal) return true;
            return IsTopMax ? ret > 0 : ret < 0;
        }
        void Swap(int a, int b)
        {
            var tmp = List[a];
            List[a] = List[b];
            List[b] = tmp;
        }
    }
}
