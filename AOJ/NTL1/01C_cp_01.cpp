// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/829857/s1210207/C++
#include <iostream>
#include <algorithm>
using namespace std;
#define gcd(a,b) __gcd(a,b)

int main(){
  int n,a,b = 1;

  cin >> n;
  for(int i = 0 ; i < n ; i++){
    cin >> a;
    b = (a*b) / gcd(a,b);
  }
  cout << b << endl;

  return 0;
}
