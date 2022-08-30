// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/3750476/kyopro_friends/C
#include <stdio.h>

int par(int*a,int l,int r){
  int pib=a[r-1];
  int crr=l;
  for(int i=l;i<r;i++){
    if(a[i]<=pib){
      int t=a[crr];
      a[crr]=a[i];
      a[i]=t;
      crr++;
    }
  }
  return crr-1;
}

int a[100010];
int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d",a+i);
  int p=par(a,0,n);
  for(int i=0;i<n;i++)printf(i==p?"[%d]%c":"%d%c",a[i],i==n-1?10:32);
}
