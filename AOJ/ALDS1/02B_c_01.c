// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/3743057/kyopro_friends/C
#include<stdio.h>
int a[110];
int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d",a+i);
  int ans=0;
  for(int i=0;i<n;i++){
    int idx=i;
    for(int j=i+1;j<n;j++){if(a[j]<a[idx]){idx=j;}}
    if(i!=idx){
      int t=a[i];
      a[i]=a[idx];
      a[idx]=t;
      ans++;
    }
  }
  for(int i=0;i<n;i++){printf("%d%c",a[i],i==n-1?10:32);}
  printf("%d\n",ans);
}
