// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/3373230/Kaz_nl/C%23
using System;
using System.Linq;

class Program {
  static int Partition(int[] a, int p, int r) {
    int x = a[r];
    int t, i = p - 1;
    for (int j = p; j < r; j++) {
      if (a[j] <= x) {
        i++;
        t = a[i];
        a[i] = a[j];
        a[j] = t;
      }
    }
    t = a[i + 1];
    a[i + 1] = a[r];
    a[r] = t;
    return i + 1;
  }
  static void Main() {
    var n = int.Parse(Console.ReadLine());
    var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var q = Partition(a, 0, n - 1);
    for (int i = 0; i < n - 1; i++) {
      if (i == q) {
        Console.Write("[{0}] ", a[i]);
      } else {
        Console.Write("{0} ", a[i]);
      }
    }
    Console.WriteLine(a[n - 1]);
  }
}
