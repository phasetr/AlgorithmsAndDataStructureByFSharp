// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/3752075/kyopro_friends/C
#include <stdio.h>
#include <string.h>
#define max(p,q)((p)>(q)?(p):(q))

int dp[1010][1010];
char s[1010],t[1010];
int main(){
  int q;
  scanf("%d",&q);
  while(q--){
    scanf("%s%s",s,t);
    int n=strlen(s);
    int m=strlen(t);
    for(int i=1;i<=n;i++)for(int j=1;j<=m;j++){
      if(s[i-1]==t[j-1])dp[i][j]=dp[i-1][j-1]+1;
      else dp[i][j]=max(dp[i-1][j],dp[i][j-1]);
    }
    printf("%d\n",dp[n][m]);
  }
}
