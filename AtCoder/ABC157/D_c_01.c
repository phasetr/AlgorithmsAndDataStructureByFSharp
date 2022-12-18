// https://atcoder.jp/contests/abc157/submissions/12306380
#include<stdio.h>
typedef struct{int Parent,Rank;}UnionFind;
UnionFind uft[100000];
int Root(int x){return(uft[x].Parent!=x)?uft[x].Parent=Root(uft[x].Parent):x;}
void Unite(int x,int y){x=Root(x),y=Root(y);if(x!=y)uft[x].Parent=y,uft[y].Rank+=uft[x].Rank;}
int Size(int x){return uft[Root(x)].Rank;}
int Belong(int x,int y){return Root(x)==Root(y);}
int main(void)
{
  int A,B,C,D,N,M,K,i,j;
  j=scanf("%d %d %d",&N,&M,&K);
  int known[N];
  for(i=0;i<N;i++){uft[i].Parent=i;uft[i].Rank=1;known[i]=0;}
  while(M--)
  {
    j=scanf("%d %d",&A,&B);
    A--,B--;known[A]++,known[B]++;Unite(A,B);
  }
  while(K--)
  {
    j=scanf("%d %d",&C,&D);
    C--,D--;if(Belong(C,D))known[C]++,known[D]++;
  }
  for(i=0;i<N;i++){printf("%d ",Size(i)-known[i]-1);}
  return printf("\n"),0;
}
