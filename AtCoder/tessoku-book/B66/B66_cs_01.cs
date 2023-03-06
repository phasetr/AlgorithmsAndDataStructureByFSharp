// https://atcoder.jp/contests/tessoku-book/submissions/35964290
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

public class P
{
    public int c { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int id { get; set; }
}

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var m = int.Parse(line[1]);
        var input = new (int, int)[m];
        for (int i = 0; i < m; i++)
        {
            line = Console.ReadLine().Trim().Split(' ');
            var a = int.Parse(line[0]) - 1;
            var b = int.Parse(line[1]) - 1;
            input[i] = (a, b);
        }
        var q = int.Parse(Console.ReadLine().Trim());
        getAns(n,m, input, q);
    }
    static void getAns(int n, int m, (int, int)[] input, int q)
    {
        var ps = new P[q];
        var unc = new HashSet<int>();
        for (int i = 0; i < q; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            var x = int.Parse(line[1]) - 1;
            if (line[0] == "1")
            {
                ps[i] = new P { c = 1, x = x, id = i };
                unc.Add(x);
            }
            else
            {
                var y = int.Parse(line[2]) - 1;
                ps[i] = new P { c = 2, x = x, y = y, id = i };
            }
        }
        var uf = new UnionFind(n);
        for (int i = 0; i < m; i++)
        {
            if (!unc.Contains(i)) uf.Unite(input[i].Item1, input[i].Item2);
        }
        var ans = new List<string>();
        foreach (var z in ps.OrderByDescending(x => x.id))
        {
            if (z.c == 1) uf.Unite(input[z.x].Item1, input[z.x].Item2);
            else
            {
                if (uf.IsSameGroup(z.x, z.y)) ans.Add("Yes");
                else ans.Add("No");
            }
        }
        ans.Reverse();
        Console.WriteLine(string.Join("\n", ans));
    }
}
