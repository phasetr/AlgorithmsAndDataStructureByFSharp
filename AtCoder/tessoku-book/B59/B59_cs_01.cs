// https://atcoder.jp/contests/tessoku-book/submissions/37476097
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
        var a = NList;
        var list = a.Select((num, idx) => (num, idx)).ToList();
        list.Sort((l, r) => r.num.CompareTo(l.num));
        var ft = new FenwickTree(n);
        var res = 0L;
        foreach (var li in list)
        {
            res += ft.Sum(li.idx);
            ft.Add(li.idx, 1);
        }
        WriteLine(res);
    }
    class FenwickTree
    {
        int size;
        long[] tree;
        public FenwickTree(int size)
        {
            this.size = size;
            tree = new long[size + 2];
        }
        public void Add(int index, long value)
        {
            ++index;
            for (var x = index; x <= size; x += (x & -x)) tree[x] += value;
        }
        /// <summary>先頭からindexまでの和(include index)</summary>
        public long Sum(int index)
        {
            ++index;
            var sum = 0L;
            for (var x = index; x > 0; x -= (x & -x)) sum += tree[x];
            return sum;
        }
    }
}
