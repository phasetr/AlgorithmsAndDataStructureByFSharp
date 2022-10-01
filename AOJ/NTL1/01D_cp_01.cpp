// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/2068862/beet/C++
#include<iostream>
using namespace std;
int eulerPhi(int n)
{
  if (n == 0) return 0;
  int ans = n;
  for (int i = 2; i*i <= n; i++) {
    if (n % i == 0) {
      ans -= ans / i;
      while (n % i == 0) n /= i;
    }
  }
  if (n > 1) ans -= ans / n;
  return ans;
}

int main(){
  int n;cin>>n;cout<<eulerPhi(n)<<endl;
  return 0;
}
