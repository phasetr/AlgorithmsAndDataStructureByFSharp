// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/3743048/kyopro_friends/C
#include<stdio.h>
#define max(p,q)((p)>(q)?(p):(q))
int M=-1e9,ans=-1e9;
void f(){
  int t;
  if(~scanf("%d",&t)){
    f();
    ans=max(ans,M-t);
    M=max(M,t);
  }
}

int main(){
  scanf("%*d");
  f();
  printf("%d\n",ans);
}
