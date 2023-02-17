// https://atcoder.jp/contests/tessoku-book/submissions/36938699
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int a = int.Parse(strs[0]);
        int b = int.Parse(strs[1]);

        long gcd = Gcd(a, b);

        long lcm = (long)a * b / gcd;

        Console.WriteLine(lcm);
    }

    private static int Gcd(int a, int b)
    {
        if (a < b)
        {
            int tmp = b;
            b = a;
            a = tmp;
        }

        while (b > 0)
        {
            int tmp = b;
            b = a % b;
            a = tmp;
        }

        return a;
    }
}
