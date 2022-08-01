// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B
#include<stdio.h>
int D[7][7]={{},
             {0,0,4,2,5,3,0},
             {0,3,0,6,1,0,4},
             {0,5,1,0,0,6,2},
             {0,2,6,0,0,1,5},
             {0,4,0,1,6,0,3},
             {0,0,3,5,2,4,0}},G[7],N,i,t,f;
int sc(int d){
  int i;
  for(i=1;i<=6;i++){if(G[i]==d) {return i;}}
  return 0;
}
int main(){
  for(i=1;i<7;i++){scanf("%d",G+i);}
  scanf("%d",&N);
  for(;N--;){
    scanf("%d%d",&t,&f);
    printf("%d\n",G[D[sc(f)][sc(t)]]);
  }
  return 0;
}
