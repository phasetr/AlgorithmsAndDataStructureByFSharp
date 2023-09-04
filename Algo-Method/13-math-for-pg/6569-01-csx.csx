using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var n = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    Console.WriteLine(solve(n[0]));
  }
  private static int solve(int n){
    var x = 0;
    for (var i=1; i<=n-1; i++) {
      for (var j=i+1; j<=n; j++) {
        x += i*j;
      }
    }
    return x;
  }
}

private void test(){
  int n = 3;
  Console.WriteLine(solve(n) == 11);
  int n = 100;
  Console.WriteLine(solve(n) == 12582075);
}
