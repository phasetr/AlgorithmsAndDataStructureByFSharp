// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/3759178/kyopro_friends/C
#include <stdio.h>
int gcd(int p,int q){while(q){int t=p%q;p=q;q=t;}return p;}

int main(){
  int n;
  scanf("%d",&n);
  int ans=n;
  for(int i=2;i*i<=n;i++){
    if(n%i==0){
      ans-=ans/i;
      while(n%i==0){n/=i;}
    }
  }
  printf("%d\n",n==1?ans:ans-ans/n);
}
