using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var lr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

    Console.WriteLine(solve(lr[0],lr[1]));
  }
  private static int solve(int l, int r){
    return Enumerable.Range(l,r-l+1).Select(x => (2*x-1)*(2*x-1)).Sum();
  }
}

private void test(){
  (int l, int r) = (2,4);
  Console.WriteLine(solve(l,r) == 83);
  (int l, int r) = (1,100);
  Console.WriteLine(solve(l,r) == 1333300);
}
