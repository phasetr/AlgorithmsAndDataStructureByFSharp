// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/3752058/kyopro_friends/C
#include <stdio.h>

int main(){
  int n;
  scanf("%d",&n);
  int a=1,b=1,c;
  while(n--)c=a+b,a=b,b=c;
  printf("%d\n",a);
}
