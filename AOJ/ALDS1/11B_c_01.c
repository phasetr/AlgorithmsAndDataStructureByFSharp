// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/1427826/s1220013/C
#include<stdio.h>

void visit(int);
int map[101][101];
int f[101],d[101],color[101],time,n;
int main(){
  int i,j,v,vv,m;

  scanf("%d",&n);
  for(i=0;i<n;i++){
    color[i]=0;
    for(j=0;j<n;j++){
      map[i][j]=0;
    }
  }
  time=0;
  for(i=0;i<n;i++){
    scanf("%d%d",&v,&m);
    for(j=0;j<m;j++){
      scanf("%d",&vv);
      map[v-1][vv-1]=1;
    }
  }
  for(i=0;i<n;i++){
    if(color[i]==0)visit(i);
  }
  for(i=0;i<n;i++){
    printf("%d %d %d\n",i+1,d[i],f[i]);
  }
  return 0;
}

void visit(int u){
  int i;
  color[u]=1;
  d[u]=++time;
  for(i=0;i<n;i++){
    if(map[u][i]==1){
      if(color[i]==0)visit(i);

    }
  }
  color[u]=2;
  f[u]=++time;
}
