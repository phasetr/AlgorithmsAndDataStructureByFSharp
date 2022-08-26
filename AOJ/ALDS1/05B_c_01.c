// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2472140/jakenu0x5e/Python3
#include <stdio.h>
#include <stdlib.h>
int upi(const void*a, const void*b){return*(int*)a-*(int*)b;}
void sortup(int*a,int n){qsort(a,n,sizeof(int),upi);}
int f(int n){
  if(n>1)return f(n/2)+f(n-n/2)+n;
  return 0;
}

int a[500010];
int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d",a+i);
  sortup(a,n);
  for(int i=0;i<n;i++)printf("%d%c",a[i],i==n-1?10:32);
  printf("%d\n",f(n));
}
