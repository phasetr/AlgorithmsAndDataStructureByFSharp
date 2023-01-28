// https://atcoder.jp/contests/tessoku-book/submissions/36132025
using System.Text;
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class UnionFind
{
    private int[] data;
    public UnionFind(int size)
    {
        data = new int[size];
        for (int i = 0; i < size; i++) data[i] = -1;
    }
    public bool Unite(int x, int y)
    {
        x = Root(x);
        y = Root(y);
        if (x != y)
        {
            if (data[y] < data[x])
            {
                var tmp = y;
                y = x;
                x = tmp;
            }
            data[x] += data[y];
            data[y] = x;
        }
        return x != y;
    }
    public bool IsSameGroup(int x, int y) => Root(x) == Root(y);
    public int Root(int x) => data[x] < 0 ? x : data[x] = Root(data[x]);
    public int getMem(int x) => -data[Root(x)];
}

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var q = int.Parse(line[1]);
        getAns(n, q);
    }
    static void getAns(int n, int q)
    {
        var uf = new UnionFind(n + 10);
        var sb = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var a = int.Parse(line[1]);
            var b = int.Parse(line[2]);
            if (line[0] == "1") uf.Unite(a, b);
            else
            {
                if (uf.IsSameGroup(a, b)) sb.Append("Yes\n");
                else sb.Append("No\n");
            }
        }
        Console.Write(sb);
    }
}
