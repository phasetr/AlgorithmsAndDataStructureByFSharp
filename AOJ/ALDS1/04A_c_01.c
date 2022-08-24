// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/3750036/kyopro_friends/C
#include <stdio.h>

int a[10010];
int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d",a+i);
  int q;
  scanf("%d",&q);
  int ans=0;
  while(q--){
    int t;
    scanf("%d",&t);
    int temp=0;
    for(int i=0;i<n;i++)temp|=a[i]==t;
    ans+=temp;
  }
  printf("%d\n",ans);
}
