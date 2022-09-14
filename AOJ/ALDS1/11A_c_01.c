// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/3752239/kyopro_friends/C
#include <stdio.h>

int a[110][110];
int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++){
    int t,k;
    scanf("%d%d",&t,&k);
    while(k--){
      int s;
      scanf("%d",&s);
      a[t][s]=1;
    }
  }
  for(int i=1;i<=n;i++)for(int j=1;j<=n;j++)printf("%d%c",a[i][j],j==n?10:32);
}
