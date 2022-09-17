// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/1438755/s1220013/C
#include<stdio.h>

int main()
{
  int i,j,n,count=0;
  int G[101][101],color[101],d[101],pi[101],mincost,ii;
  scanf("%d",&n);
  for(i=0;i<n;i++){
    for(j=0;j<n;j++){
      scanf("%d",&G[i][j]);
    }
  }
  for(i=0;i<n;i++){
    color[i]=0;
    pi[i]=-1;
    d[i]=2001;
  }
  d[0]=0;

  while(1){
    mincost=2001;
    for(i=0;i<n;i++){
      if(color[i]!=2 && d[i]<mincost){
        mincost=d[i];
        ii=i;
      }
    }
    if(mincost==2001)break;
    color[ii]=2;
    for(i=0;i<n;i++){
      if(G[ii][i]!=-1 && color[i]!=2 && G[ii][i]<d[i]){
        pi[i]=ii;
        d[i]=G[ii][i];
        color[i]=1;
      }
    }
  }
  for(i=0;i<n;i++){
    if(pi[i]!=-1)count+=G[i][pi[i]];
    }
  printf("%d\n",count);
  return 0;
}
