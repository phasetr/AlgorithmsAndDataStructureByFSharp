// https://atcoder.jp/contests/tessoku-book/submissions/36384777
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoderLib8.Graphs.Arrays;

class A61
{
  static int[] Read() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  static (int, int) Read2() { var a = Read(); return (a[0], a[1]); }
  static void Main()
  {
    var (n, m) = Read2();
    var es = Array.ConvertAll(new bool[m], _ => Read());
    var sb = new StringBuilder();

    var map = PathCore.ToListMap(n + 1, es, true);
    for (int v = 1; v <= n; v++)
    {
      sb.AppendLine($"{v}: {{{string.Join(", ", map[v])}}}");
    }
    Console.Write(sb);
  }
}

namespace CoderLib8.Graphs.Arrays
{
  public static class PathCore
  {
    public static T[][] ToArrays<T>(this List<T>[] map) => Array.ConvertAll(map, l => l.ToArray());
    public static int[][] ToMap(int n, int[][] es, bool twoWay) => ToListMap(n, es, twoWay).ToArrays();
    public static List<int>[] ToListMap(int n, int[][] es, bool twoWay)
    {
      var map = Array.ConvertAll(new bool[n], _ => new List<int>());
      foreach (var e in es)
      {
        map[e[0]].Add(e[1]);
        if (twoWay) map[e[1]].Add(e[0]);
      }
      return map;
    }
  }
}
