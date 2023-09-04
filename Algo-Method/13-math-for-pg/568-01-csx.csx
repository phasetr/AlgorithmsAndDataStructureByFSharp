using System;
using System.Linq;
class Program{
  static void Main(string[] args){
    var nm = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
    var b = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

    Console.WriteLine(solve(nm[0],nm[1],a,b));
  }
  private static int solve(int n, int m, int[] a, int[] b){
    int x = 0;
    for (var i=0; i<n; i++) {
      for (var j=0; j<m; j++) {
        x += a[i]+b[j];
      }
    }
    return x;
  }
}

private void test(){
  (int n, int m, int[] a, int[] b) = (2,3,new int[] {1,2}, new int[] {3,4,5});
  Console.WriteLine(solve(n,m,a,b) == 33);
  (int n, int m, int[] a, int[] b) = (10,10,new int[] {1,1,1,1,1,1,1,1,1,1},new int[] {1,1,1,1,1,1,1,1,1,1});
  Console.WriteLine(solve(n,m,a,b) == 200);
}
