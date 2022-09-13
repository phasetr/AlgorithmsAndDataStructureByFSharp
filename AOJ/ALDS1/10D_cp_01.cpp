// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/4240929/hryshtk/C++
#include <iostream>
using namespace std;
double P[505],Q[505],dp[505][505],S[505][505],a1,a2;
int n,i,j,k,m;
int main(){
  cin>>n;
  for(i=1;i<=n;i++)scanf("%lf",&P[i]);
  for(i=0;i<=n;i++)scanf("%lf",&Q[i]);
  for(i=1;i<=n;i++){
    dp[i][i]=P[i]+2*(Q[i-1]+Q[i]);
    S[i][i]=P[i]+Q[i-1]+Q[i];
  }
  for(k=1;k<n;k++)
    for(i=1;i<=n-k;i++){
      j=i+k;
      S[i][j]=S[i][j-1]+P[j]+Q[j];
      a1=S[i][j]+Q[i-1]+dp[i+1][j];
      a2=S[i][j]+Q[j]+dp[i][j-1];
      dp[i][j]=min(a1,a2);
      for(m=i+1;m<j;m++)dp[i][j]=min(dp[i][j],S[i][j]+dp[i][m-1]+dp[m+1][j]);
    }
  printf("%.8lf\n",dp[1][n]);
  return 0;
}
