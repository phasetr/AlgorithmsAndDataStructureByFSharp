using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var nm = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    Console.WriteLine(solve(nm[0],nm[1],a));
  }
  private static int solve(int n, int m, int[] a){
    var mod = 1000;
    int[,] dp = new int[n+1,m+1];
    dp[0,0] = 1;
    Enumerable.Range(0,n).ToList().ForEach(i => {
      Enumerable.Range(0,m+1).ToList().ForEach(j => {
        dp[i+1,j] = j<a[i] ? dp[i,j] : (dp[i,j]+dp[i,j-a[i]])%mod;
        });});
    return dp[n,m];
  }
}

private void test(){
  (int n, int m, int[] a) = (5,12,new int[] {7,5,3,1,8});
  Console.WriteLine(solve(n,m,a) == 2);
  (int n, int m, int[] a) = (4,5,new int[] {4,1,1,1});
  Console.WriteLine(solve(n,m,a) == 3);
}
