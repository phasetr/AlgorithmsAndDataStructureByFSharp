// https://atcoder.jp/contests/tessoku-book/submissions/37646066
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var n = long.Parse(ReadLine());
        var list = new List<long>();
        var rev = new List<long>();
        for (var i = 1L; i * i <= n; ++i)
        {
            if (n % i == 0)
            {
                list.Add(i);
                if (i * i < n) rev.Add(n / i);
            }
        }
        rev.Reverse();
        list.AddRange(rev);
        WriteLine(string.Join("\n", list));
    }
}
