// https://atcoder.jp/contests/tessoku-book/submissions/37429929
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int NN => int.Parse(ReadLine());
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = NN;
        var q = new PriorityQueue<int>(n, false);
        var res = new List<int>();
        for (var i = 0; i < n; ++i)
        {
            var c = NList;
            if (c[0] == 1) q.Enqueue(c[1]);
            else if (c[0] == 2) res.Add(q.List[0]);
            else q.Dequeue();
        }
        WriteLine(string.Join("\n", res));
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
