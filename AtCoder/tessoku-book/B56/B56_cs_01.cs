// https://atcoder.jp/contests/tessoku-book/submissions/37463848
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

        var h1 = new StringHash(s);
        var h2 = new StringHash(string.Concat(s.Reverse()));

        var res = new bool[q];
        for (var i = 0; i < q; ++i)
        {
            c = NList;
            var a1 = h1.Hash1(c[0] - 1, c[1] - 1);
            var b1 = h2.Hash1(n - c[1], n - c[0]);
            var a2 = h1.Hash2(c[0] - 1, c[1] - 1);
            var b2 = h2.Hash2(n - c[1], n - c[0]);
            res[i] = a1 == b1 && a2 == b2;
        }
        WriteLine(string.Join("\n", res.Select(f => f ? "Yes" : "No")));
    }
    class StringHash
    {
        int mul1 = 29;
        int mul2 = 31;
        int mod1 = 998_244_391;
        int mod2 = 998_244_397;
        long[] pow1;
        long[] pow2;
        long[] hash1;
        long[] hash2;
        public StringHash(string s)
        {
            pow1 = new long[s.Length + 1];
            pow1[0] = 1;
            pow2 = new long[s.Length + 1];
            pow2[0] = 1;
            hash1 = new long[s.Length + 1];
            hash2 = new long[s.Length + 1];
            for (var i = 1; i <= s.Length; ++i)
            {
                pow1[i] = pow1[i - 1] * mul1 % mod1;
                pow2[i] = pow2[i - 1] * mul2 % mod2;
                hash1[i] = (hash1[i - 1] * mul1 + s[i - 1] - 'a' + 1) % mod1;
                hash2[i] = (hash2[i - 1] * mul2 + s[i - 1] - 'a' + 1) % mod2;
            }
        }
        public int Hash1(int l, int r)
        {
            return (int)((hash1[r + 1] + mod1 - hash1[l] * pow1[r - l + 1] % mod1) % mod1);
        }
        public int Hash2(int l, int r)
        {
            return (int)((hash2[r + 1] + mod1 - hash2[l] * pow2[r - l + 1] % mod2) % mod2);
        }
    }
}
