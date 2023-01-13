// https://atcoder.jp/contests/tessoku-book/submissions/35761559
using System.Linq;
using static System.Math;
using System.Collections.Generic;
using System;

public class hello
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine().Trim());
        getAns(n);
    }
    static void getAns(int n)
    {
        var st = new Stack<string>();
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            if (line[0] == "1") st.Push(line[1]);
            else if (line[0] == "2") Console.WriteLine(st.Peek());
            else st.Pop();
        }
    }
}
