// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/800796/ei1333/C++
#include<iostream>
using namespace std;
int main(){
  int n,dp[45]={1,1};
  cin >> n;
  for(int i = 2 ; i <= n ; i++ ) dp[i] = dp[i-1] + dp[i-2];
  cout << dp[n] << endl;
}
