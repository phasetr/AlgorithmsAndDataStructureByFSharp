// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/3752702/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>
#define bit(n,m)(((n)>>(m))&1)

int a[8];

void f(int l,int m,int r,int n){
  if(n==8){
    for(int i=0;i<8;i++){
      for(int j=0;j<8;j++){putchar(a[i]==j?'Q':'.');}
      puts("");
    }
    exit(0);
  }
  if(a[n]!=-1){
    int t=1<<a[n];
    if(!bit(l|m|r,a[n])){f((l|t)<<1,(m|t),(r|t)>>1,n+1);}
    return;
  }
  for(int j=0;j<8;j++){
    if(!bit(l|m|r,j)){
      a[n]=j;
      int t=1<<j;
      f((l|t)<<1,(m|t),(r|t)>>1,n+1);
      a[n]=-1;
    }
  }
}

int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<8;i++){a[i]=-1;}
  while(n--){
    int x,y;
    scanf("%d%d",&x,&y);
    a[x]=y;
  }
  f(0,0,0,0);
}
