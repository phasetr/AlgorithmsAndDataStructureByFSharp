// https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/2921641/simkaren/C%23
using System;
using System.Collections.Generic;
class P
{
  static int v;
  static long[] d;
  static int r;
  static Graph g;
  static long inf = long.MaxValue - 10000;
  static void Main()
  {
    string[] str = Console.ReadLine().Split();
    int e;
    v = int.Parse(str[0]);
    e = int.Parse(str[1]);
    r = int.Parse(str[2]);
    d = new long[v];
    g = new Graph();
    for (int i = 0; i < e; i++)
    {
      str = Console.ReadLine().Split();
      int s, t, d2;
      s = int.Parse(str[0]);
      t = int.Parse(str[1]);
      d2 = int.Parse(str[2]);
      g.SetEdge(s, t, d2);
    }
    BellmanFord(r);
    foreach (var i in d)
    {
      if (i == inf)
        Console.WriteLine("INF");
      else
        Console.WriteLine(i);
    }
  }
  static void BellmanFord(int s)
  {
    for (int i = 0; i < v; i++)
      d[i] = inf;
    d[s] = 0;
    for (int i = 0; i < v - 1; i++)
    {
      bool f = false;
      foreach (var e in g.edges)
      {
        if (d[e.goal] > d[e.start] + e.Length)
        {
          d[e.goal] = d[e.start] + e.Length;
          f = true;
        }
      }
      if (!f)
        break;
    }
  }
}
struct Edge
{
  public int start;
  public int goal;
  public int Length;
  public Edge(int s, int g, int l)
  {
    start = s;
    goal = g;
    Length = l;
  }
}
class Graph
{
  public List<Edge> edges = new List<Edge>();
  public void SetEdge(int s, int g, int l)
  {
    edges.Add(new Edge(s, g, l));
  }
}
