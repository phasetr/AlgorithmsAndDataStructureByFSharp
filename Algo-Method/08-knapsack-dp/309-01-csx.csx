using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var nm = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    Console.WriteLine(solve(n,m,a));
  }
  private static string solve(int n, int m, int[] a){
    bool[,] dp = new bool[n+1, m+1];
    dp[0,0] = true;
    for(int i = 0; i < n; i++) {
      for(int j = 0; j <= m; j++) {
        dp[i+1,j] = j < a[i] ? dp[i,j] : dp[i,j] || dp[i,j-a[i]];
      }
    }
    return dp[n,m] ? "Yes" : "No";
  }
}

private void test(){
  (int n, int m, int[] a) = (3,10,new int[] {7,5,3});
  Console.WriteLine(solve(n,m,a) == "Yes");

  (int n, int m, int[] a) = (2,6,new int[] {9,7});
  Console.WriteLine(solve(n,m,a) == "No");
}
