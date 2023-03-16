// https://atcoder.jp/contests/tessoku-book/submissions/37675549
using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static long[] NList => ReadLine().Split().Select(long.Parse).ToArray();
    public static void Main()
    {
        Solve();
    }
    static void Solve()
    {
        var c = NList;
        var (n, p) = (c[0], c[1]);
        var a = NList;
        var mod = 1_000_000_007;
        var dic = new Dictionary<long, int>();
        foreach (var ai in a)
        {
            var am = ai % mod;
            if (dic.ContainsKey(am)) ++dic[am];
            else dic[am] = 1;
        }
        if (p == 0)
        {
            if (dic.ContainsKey(0))
            {
                WriteLine((long)dic[0] * (dic[0] - 1) / 2 + (long)dic[0] * (n - dic[0]));
            }
            else
            {
                WriteLine(0);
            }
            return;
        }
        var keys = dic.Keys;
        var ans = 0L;
        foreach (var k in keys)
        {
            if (!dic.ContainsKey(k)) continue;
            var revk = PowMod(k, mod - 2, mod) * p % mod;
            if (k == revk)
            {
                ans += (long)dic[k] * (dic[k] - 1) / 2;
                dic.Remove(k);
            }
            else if (dic.ContainsKey(revk))
            {
                ans += (long)dic[k] * dic[revk];
                dic.Remove(k);
                dic.Remove(revk);
            }
        }
        WriteLine(ans);
    }
    static int PowMod(long n, int p, int mod)
    {
        var _n = n % mod;
        var _p = p;
        var result = 1L;
        if ((_p & 1) == 1) result *= _n;
        while (_p > 0)
        {
            _n = _n * _n % mod;
            _p >>= 1;
            if ((_p & 1) == 1) result = (result * _n) % mod;
        }
        return (int)result;
    }
}
