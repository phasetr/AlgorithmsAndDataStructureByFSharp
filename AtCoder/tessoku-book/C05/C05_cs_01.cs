// https://atcoder.jp/contests/tessoku-book/submissions/37646122
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
        var n = int.Parse(ReadLine());
        --n;
        var ans = "4444444444".ToCharArray();
        for (var i = 9; i >= 0; --i)
        {
            if (n % 2 == 1) ans[i] = '7';
            n >>= 1;
        }
        WriteLine(string.Concat(ans));
    }
}
