using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var s = Console.ReadLine();
    var t = Console.ReadLine();
    Console.WriteLine(solve(s,t));
  }
  private static int solve(string s, string t){
    var sLen = s.Length;
    var tLen = t.Length;
    int[,] dp = new int[sLen+1,tLen+1];
    for (var i=0; i<sLen; i++) {
      for (var j=0; j<tLen; j++) {
        dp[i+1,j+1] = s[i] == t[j]
          ? Math.Max(dp[i,j]+1, Math.Max(dp[i+1,j], dp[i,j+1]))
          : Math.Max(dp[i+1,j], dp[i,j+1]);
      }
    }
    return dp[sLen,tLen];
  }
}

private void test(){
  (string s, string t) = ("abcde", "acbef");
  Console.WriteLine(solve(s,t) == 3);
  (string s, string t) = ("abracadabra", "aabraardba");
  Console.WriteLine(solve(s,t) == 8);
}
