// https://atcoder.jp/contests/tessoku-book/submissions/38027028
using System;
using System.Collections.Generic;

public struct Price : IComparable<Price>
{
    public int d;
    public int p;

    public int CompareTo(Price x)
    {
        return p - x.p;
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);

        int[] ais = new int[n];

        strs = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            ais[i] = int.Parse(strs[i]);
        }

        int[] ds = new int[n];

        Stack<Price> pst = new Stack<Price>();

        Price pr = new Price();

        for (int i = 0; i < n; i++)
        {
            ds[i] = -1;
            while(pst.Count > 0)
            {
                pr = pst.Peek();

                if(pr.p > ais[i])
                {
                    ds[i] = pr.d;
                    break;
                }
                else
                {
                    pst.Pop();
                }
            }

            pr.d = i + 1;
            pr.p = ais[i];
            pst.Push(pr);
        }

        Console.WriteLine(string.Join(" ", ds));
    }
}


