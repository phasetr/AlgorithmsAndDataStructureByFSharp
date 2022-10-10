// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/4135197/ngtkana/C%23
using System;
using System.Linq;
using System.Collections.Generic;

public static class Program {
  public static void Main() {
    int[]nq=Console.ReadLine().Split().Select(int.Parse).ToArray();
    int n=nq[0];
    int q=nq[1];

    int[]prt=new int[n];
    for(int i=0;i<n;i++){
      prt[i]=-1;
    }
    Func<int,int>find=null;
    find=x=>prt[x]<0?x:prt[x]=find(prt[x]);
    for(int i=0;i<q;i++){
      int[]query=Console.ReadLine().Split().Select(int.Parse).ToArray();
      if(query[0]==0){
        int u=find(query[1]);
        int v=find(query[2]);
        if(u!=v)prt[u]=v;
      }else{
        Console.WriteLine(find(query[1])==find(query[2])?1:0);
      }
    }
  }
}
