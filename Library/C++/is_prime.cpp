// https://atcoder.jp/contests/arc017/tasks/arc017_1
// https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-1-素数判定
#include <iostream>
using namespace std;
using ll = long long;

bool isPrime(ll n) {
  if (n == 1) return false;
  for (ll i = 2; i * i < n + 1; i++) {
    if (n % i == 0) return false;
  }
  return true;
}

int main() {
  ll n;
  cin >> n;
  if (isPrime(n))
    cout << "YES" << endl;
  else
    cout << "NO" << endl;
  return 0;
}
