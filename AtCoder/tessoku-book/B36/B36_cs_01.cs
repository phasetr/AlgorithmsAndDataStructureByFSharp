// https://atcoder.jp/contests/tessoku-book/submissions/35781949
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var k = int.Parse(line[1]);
        var s = Console.ReadLine().Trim();
        getAns(n, k, s);
    }
    static void getAns(int n, int k, string s)
    {
        var c1 = s.Count(x => x == '1');
        Console.WriteLine((k - c1) % 2 == 0 ? "Yes" : "No");
    }
}
