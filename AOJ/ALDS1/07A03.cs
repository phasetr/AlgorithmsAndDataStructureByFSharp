// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/4774187/keymoon/C%23
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] parents = Enumerable.Repeat(-1, n).ToArray();
        int[][] childs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var id = data[0];
            childs[id] = data.Skip(2).ToArray();
            foreach (var child in childs[id])
                parents[child] = id;
        }

        int[] depths = new int[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(Array.IndexOf(parents, -1));
        while (0 < stack.Count)
        {
            var elem = stack.Pop();
            foreach (var item in childs[elem])
            {
                depths[item] = depths[elem] + 1;
                stack.Push(item);
            }
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"node {i}: parent = {parents[i]}, depth = {depths[i]}, {(parents[i] == -1 ? "root" : childs[i].Length == 0 ? "leaf" : "internal node")}, [{string.Join(", ", childs[i])}]");
        }
    }
}

