// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/3759161/kyopro_friends/C
#include <stdio.h>
int gcd(int p,int q){while(q){int t=p%q;p=q;q=t;}return p;}

int main(){
  int n;
  scanf("%d",&n);
  long ans=1;
  while(n--){
    int t;
    scanf("%d",&t);
    ans=ans/gcd(ans,t)*t;
  }
  printf("%ld\n",ans);
}
