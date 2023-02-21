// https://atcoder.jp/contests/tessoku-book/submissions/35785026
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class PriorityQueue<T> where T : IComparable
{
    private IComparer<T> _comparer = null;
    private int _type = 0;
    private T[] _heap;
    private int _sz = 0;
    private int _count = 0;
    public PriorityQueue(int maxSize, IComparer<T> comparer)
    {
        _heap = new T[maxSize];
        _comparer = comparer;
    }
    public PriorityQueue(int maxSize, int type = 0)
    {
        _heap = new T[maxSize];
        _type = type;
    }
    private int Compare(T x, T y)
    {
        if (_comparer != null) return _comparer.Compare(x, y);
        return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
    }
    public void Push(T x)
    {
        _count++;
        var i = _sz++;
        while (i > 0)
        {
            var p = (i - 1) / 2;
            if (Compare(_heap[p], x) <= 0) break;
            _heap[i] = _heap[p];
            i = p;
        }
        _heap[i] = x;
    }
    public T Pop()
    {
        _count--;
        T ret = _heap[0];
        T x = _heap[--_sz];
        int i = 0;
        while (i * 2 + 1 < _sz)
        {
            int a = i * 2 + 1;
            int b = i * 2 + 2;
            if (b < _sz && Compare(_heap[b], _heap[a]) < 0) a = b;
            if (Compare(_heap[a], x) >= 0) break;
            _heap[i] = _heap[a];
            i = a;
        }
        _heap[i] = x;
        return ret;
    }
    public int Count() => _count;
    public T Peek() => _heap[0];
    public bool Contains(T x)
    {
        for (int i = 0; i < _sz; i++) if (x.Equals(_heap[i])) return true;
        return false;
    }
    public void Clear()
    {
        while (this.Count() > 0) this.Pop();
    }
    public IEnumerator<T> GetEnumerator()
    {
        var ret = new List<T>();
        while (this.Count() > 0)
        {
            ret.Add(this.Pop());
        }
        foreach (var r in ret)
        {
            this.Push(r);
            yield return r;
        }
    }
    public T[] ToArray()
    {
        T[] array = new T[_sz];
        int i = 0;
        foreach (var r in this)
        {
            array[i++] = r;
        }
        return array;
    }
}

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var d = int.Parse(line[1]);
        var aa = new List<int>[d];
        for (int i = 0; i < d; i++) aa[i] = new List<int>();
        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine().Trim().Split(' ');
            var x = int.Parse(line[0]) - 1;
            var y = int.Parse(line[1]);
            aa[x].Add(y);
        }
        getAns(d, n, aa);
    }
    static void getAns(int d, int n, List<int>[] aa)
    {
        var pq = new PriorityQueue<int>(n + 10, 1);
        var ans = 0L;
        for (int i = 0; i < d; i++)
        {
            foreach (var x in aa[i]) pq.Push(x);
            if (pq.Count() > 0) ans += pq.Pop();
        }
        Console.WriteLine(ans);
    }
}
