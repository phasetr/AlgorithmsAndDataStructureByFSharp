// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/1907260/beet/C++
#include<iostream>
using namespace std;
typedef long long ll;
int main(){
  ll n,mi=10000000000,ma=-10000000000,r;
  cin >> n;
  for(int i=0;i<n;i++){
    cin>>r;
    ma=max(ma,r-mi);
    mi=min(mi,r);
  }
  cout << ma << endl;
  return 0;
}
