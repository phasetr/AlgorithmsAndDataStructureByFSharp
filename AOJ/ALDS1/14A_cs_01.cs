// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/1969729/JCz1fc17/C%23
using System;

public class Program
{
  public static void Main()
  {
    string T = Console.ReadLine();
    string P = Console.ReadLine();
    for (int i = 0; i < T.Length - P.Length + 1; i++)
    {
      if (T.Substring(i, P.Length) == P)
      {
        Console.WriteLine(i);
      }
    }
  }
}
