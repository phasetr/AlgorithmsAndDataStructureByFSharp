// https://atcoder.jp/contests/tessoku-book/submissions/35780726
using System.Numerics;
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var a = int.Parse(line[0]);
        var b = long.Parse(line[1]);
        var ans = BigInteger.ModPow(a, b, 1000000007);
        Console.WriteLine(ans);
    }
}
