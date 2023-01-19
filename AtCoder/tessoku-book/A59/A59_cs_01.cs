// https://atcoder.jp/contests/tessoku-book/submissions/37475933
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

static int NN => int.Parse(ReadLine());
static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
static void Solve()
{
  var c = NList;
  var (n, q) = (c[0], c[1]);
  var ft = new FenwickTree(n + 2);
  var res = new List<long>();
  for (var i = 0; i < q; ++i)
  {
    c = NList;
    if (c[0] == 1)
    {
      ft.Add(c[1], c[2] - ft.Sum(c[1]) + ft.Sum(c[1] - 1));
    }
    else
    {
      res.Add(ft.Sum(c[2] - 1) - ft.Sum(c[1] - 1));
    }
  }
  WriteLine(string.Join("\n", res));
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

Solve();
