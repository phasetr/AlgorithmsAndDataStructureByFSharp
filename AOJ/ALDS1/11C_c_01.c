// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/6279630/vjudge2/C
#include<stdio.h>
#define Num 101

int var1[Num][Num],V[Num],E[Num],n;

void cari(int x, int y){
  int L;
  V[x] = y;
  for(L=1;L<=E[x];L++)
    if(y+1<V[var1[x][L]]) cari(var1[x][L], y + 1);
}

int main(){
  int i,j,k;
  scanf("%d",&n);
  for(i=1;i<=n;i++){
    V[i]=Num;
    scanf("%d",&k);
    scanf("%d",&E[k]);
    for(j=1;j<=E[k];j++){
      scanf("%d",&var1[k][j]);
    }
  }
  cari(1,0);
  for(i=1;i<=n;i++) if(V[i]==Num)V[i]=-1;
  for(i=1;i<=n;i++) printf("%d %d\n",i,V[i]);
  return 0;
}
