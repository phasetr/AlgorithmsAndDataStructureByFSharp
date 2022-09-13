// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/1005674/dohatsu/C++
#include<iostream>
#include<algorithm>
using namespace std;
int dp[1001][1001];
string s,t;
int n,m,a,ans;
int main(){
  cin>>a;
  for(int b=0;b<a;b++){
    cin>>s>>t;
    for(int i=0;i<=1000;i++){
      for(int j=0;j<=1000;j++){
        dp[i][j]=0;}}
    m=s.size();
    n=t.size();
    ans=0;
    for(int i=1;i<=m;i++){
      for(int j=1;j<=n;j++){
        if(s[i-1]==t[j-1]){
          dp[i][j]=dp[i-1][j-1]+1;
        }else{
          dp[i][j]=max(dp[i-1][j],dp[i][j-1]);
        }
      }
    }
    cout<<dp[m][n]<<endl;
  }
  return 0;
}
