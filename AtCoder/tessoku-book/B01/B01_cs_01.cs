// https://atcoder.jp/contests/tessoku-book/submissions/37366039
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var in1 = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        Console.WriteLine(in1.Sum());
    }
}
