// https://atcoder.jp/contests/tessoku-book/submissions/36928308
using System;
using System.Linq;

namespace KyoPro
{
    internal class KyoPro
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for(int i = input[0]; i <= input[1]; i++)
            {
                if(100 % i == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
        }
    }
}
