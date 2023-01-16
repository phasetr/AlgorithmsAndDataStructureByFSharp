// https://atcoder.jp/contests/tessoku-book/submissions/37447352
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int NN => int.Parse(ReadLine());
    static int[] NList => ReadLine().Split().Select(int.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, q) = (c[0], c[1]);
        var s = ReadLine();

        var mul1 = 29;
        var mul2 = 31;
        var mod1 = 998_244_391;
        var mod2 = 998_244_397;
        var pow1 = new long[n + 1];
        pow1[0] = 1;
        var pow2 = new long[n + 1];
        pow2[0] = 1;
        var hash1 = new long[n + 1];
        var hash2 = new long[n + 1];
        for (var i = 1; i <= n; ++i)
        {
            pow1[i] = pow1[i - 1] * mul1 % mod1;
            pow2[i] = pow2[i - 1] * mul2 % mod2;
            hash1[i] = (hash1[i - 1] * mul1 + s[i - 1] - '0') % mod1;
            hash2[i] = (hash2[i - 1] * mul2 + s[i - 1] - '0') % mod2;
        }
        var res = new bool[q];
        for (var i = 0; i < q; ++i)
        {
            c = NList;
            var a1 = (hash1[c[1]] + mod1 - hash1[c[0] - 1] * pow1[c[1] - c[0] + 1] % mod1) % mod1;
            var b1 = (hash1[c[3]] + mod1 - hash1[c[2] - 1] * pow1[c[3] - c[2] + 1] % mod1) % mod1;
            var a2 = (hash2[c[1]] + mod2 - hash2[c[0] - 1] * pow2[c[1] - c[0] + 1] % mod2) % mod2;
            var b2 = (hash2[c[3]] + mod2 - hash2[c[2] - 1] * pow2[c[3] - c[2] + 1] % mod2) % mod2;
            res[i] = a1 == b1 && a2 == b2;
        }
        WriteLine(string.Join("\n", res.Select(f => f ? "Yes" : "No")));
    }
}
