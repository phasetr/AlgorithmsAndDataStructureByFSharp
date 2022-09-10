// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/3752052/kyopro_friends/C
#include <stdio.h>
int n;
int a[500010];
void f(int i){
  int idx=i;
  if(2*i  <=n&&a[2*i  ]>a[idx])idx=2*i;
  if(2*i+1<=n&&a[2*i+1]>a[idx])idx=2*i+1;
  if(idx!=i){
    int t=a[i];
    a[i]=a[idx];
    a[idx]=t;
    f(idx);
  }
}
int main(){
  scanf("%d",&n);
  for(int i=1;i<=n;i++)scanf("%d",a+i);
  for(int i=n;i>0;i--)f(i);
  for(int i=1;i<=n;i++)printf(" %d",a[i]);
  puts("");
}
