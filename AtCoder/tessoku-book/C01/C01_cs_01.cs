// https://atcoder.jp/contests/tessoku-book/submissions/38275931
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);

        Console.WriteLine((int)(n * 1.1));
    }
}
