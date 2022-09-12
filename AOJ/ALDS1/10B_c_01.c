// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/3752067/kyopro_friends/C
#include <stdio.h>
#define min(p,q)((p)<(q)?(p):(q))

int dp[110][110];
int a[110],b[110];
int f(int l,int r){
  if(dp[l][r])return dp[l][r];
  if(l+1==r)return 0;
  int ans=1e9;
  for(int m=l+1;m<r;m++)ans=min(ans,f(l,m)+f(m,r)+a[l]*a[m]*b[r-1]);
  return dp[l][r]=ans;
}

int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d%d",a+i,b+i);
  printf("%d\n",f(0,n));
}
