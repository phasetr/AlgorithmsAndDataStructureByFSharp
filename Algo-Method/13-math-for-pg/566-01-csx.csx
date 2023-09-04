using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var n = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

    Console.WriteLine(solve(n[0]));
  }
  private static int solve(int n){
    return Enumerable.Range(1,n).Sum();
  }
}

private void test(){
  var n = 3;
  Console.WriteLine(solve(n) == 6);
  var n = 100;
  Console.WriteLine(solve(n) == 5050);
}
