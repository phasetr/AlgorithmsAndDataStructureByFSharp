// https://atcoder.jp/contests/tessoku-book/submissions/35797722
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        string[] line = Console.ReadLine().Trim().Split(' ');
        var n = int.Parse(line[0]);
        var x = int.Parse(line[1]) - 1;
        var s = Console.ReadLine().Trim();
        getAns(n, x, s);
    }
    static void getAns(int n, int x, string s)
    {
        var q = new Queue<int>();
        var a = s.ToCharArray();
        q.Enqueue(x);
        a[x] = '@';
        while (q.Count > 0)
        {
            var w = q.Dequeue();
            if (w - 1 >= 0 && a[w - 1] == '.') { a[w - 1] = '@'; q.Enqueue(w - 1); }
            if (w + 1 < n && a[w + 1] == '.') { a[w + 1] = '@'; q.Enqueue(w + 1); }
        }
        Console.WriteLine(new string(a));
    }
}
