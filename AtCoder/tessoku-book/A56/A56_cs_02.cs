// https://atcoder.jp/contests/tessoku-book/submissions/36207966
using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        List<int> A = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
        int n = A[0];
        int q = A[1];
        string s = Console.ReadLine();

        long p = 31;
        long mod = (long) (1e9 + 7);

        long[] pow = new long[n + 1];
        pow[0] = 1;
        Enumerable.Range(0, n).ToList().ForEach(i => pow[i + 1] = (pow[i] * p) % mod);

        long[] hash = new long[n + 1];
        Enumerable.Range(0, n).ToList().ForEach(i => hash[i + 1] = (hash[i] + pow[i] * (s[i] - 'a' + 1)) % mod);

        Enumerable.Range(0, q).ToList().ForEach(i => {
            List<int> abcd = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
            int a = abcd[0];
            int b = abcd[1];
            int c = abcd[2];
            int d = abcd[3];

            long ba = ((hash[b] - hash[a - 1] + mod) % mod) * pow[n - a] % mod;
            long dc = ((hash[d] - hash[c - 1] + mod) % mod) * pow[n - c] % mod;
            Console.WriteLine(ba == dc? "Yes" : "No");
        });
    }
}

