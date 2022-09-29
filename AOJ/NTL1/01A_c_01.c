// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3759138/kyopro_friends/C
#include <stdio.h>
int main(){
  int n;
  scanf("%d",&n);
  printf("%d:",n);
  for(int i=2;i*i<=n;i++)if(n%i==0)printf(" %d",i),n/=i--;
  printf(n==1?"\n":" %d\n",n);
}
