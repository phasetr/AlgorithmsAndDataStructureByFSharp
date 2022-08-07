// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/1276615/kzyKT/C
#include <stdio.h>
int main() {
  int n;
  scanf("%d",&n);
  int ans=-1000000000,M=1000000000,i;
  for(i=0; i<n; i++) {
    int x;
    scanf("%d",&x);
    if(i && x-M>ans) ans=x-M;
    if(M>x) M=x;
  }
  printf("%d\n",ans);
  return 0;
}
