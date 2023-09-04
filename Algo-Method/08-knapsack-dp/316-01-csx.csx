using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var nm = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    int[,] c = new int[nm[0],nm[1]];
    for (var i=0; i<nm[0]; i++) {
      var l = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
      for (var j=0; j<nm[1]; j++) { c[i,j] = l[j]; }
    }
    Console.WriteLine(solve(nm[0],nm[1],c));
  }
  private static int solve(int n, int m, int[,] c){
    var inf = 100000000;
    int [,] dp = new int[n+1,m+1];
    for (var j=0; j<m; j++) { dp[0,j] = inf; }
    for (var i=0; i<n; i++) {
      for (var j=0; j<m; j++) {
        dp[i+1,j+1] = Math.Min(dp[i,j], Math.Min(dp[i+1,j], dp[i,j+1])) + c[i,j];
      }
    }
    return dp[n,m];
  }
}

private void test(){
  (int n, int m, int[,] c) = (2,3,new int[,] {{1,2,3},{4,3,2}});
  Console.WriteLine(solve(n,m,c) == 5);
  (int n, int m, int[,] c) = (5,5,new int[,] {{1,1,10,10,10},{10,1,1,10,10},{10,1,10,10,10},{10,1,1,1,10},{10,10,1,1,1}});
  Console.WriteLine(solve(n,m,c) == 6);
}
