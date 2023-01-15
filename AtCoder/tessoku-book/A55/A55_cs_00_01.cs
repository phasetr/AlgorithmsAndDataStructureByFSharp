// https://atcoder.jp/contests/tessoku-book/submissions/37623810
using System;
using System.Collections.Generic;

struct Query
{
  public int q;
  public int x;
}

// int q = 3
// Query[] qs = {new Query{q=1,x=77}, new Query{q=3,x=40}, new Query{q=3,x=80}}

// int q = 3
// Query[] qs = {new Query{q=1,x=77}, new Query{q=1,x=40}, new Query{q=2,x=40}}

private static void Solve(int q, Query[] qs)
{
  List<int> ls = new List<int>();

  for (int i = 0; i < q; i++)
  {
    switch (qs[i].q)
    {
      case 1:
        if(ls.Count == 0)
        {
          ls.Add(qs[i].x);
        }
        else
        {
          int j = ls.BinarySearch(qs[i].x);
          ls.Insert(~j, qs[i].x);
        }
        break;
      case 2:
        ls.Remove(qs[i].x);
        break;
      default:
        int s = ls.BinarySearch(qs[i].x);
        s = (s >= 0) ? s : ~s;
        Console.WriteLine((s < ls.Count) ? ls[s] : -1);
        break;
    }
  }
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
  Solve(q,qs);
}
