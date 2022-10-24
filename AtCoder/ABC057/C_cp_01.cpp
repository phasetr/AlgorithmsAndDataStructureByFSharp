// https://atcoder.jp/contests/abc057/tasks/abc057_c
// https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-3-abc-057-c---digits-in-multiplication-300-点
#include <algorithm>
#include <iostream>
using namespace std;
using ll = long long;

int calc_digit(ll N) {
  int res = 0;
  while (N) {
    ++res;
    N /= 10;
  }
  return res;
}

int main() {
  ll N;
  cin >> N;
  int res = (1 << 29);  // 十分大きい値で初期化
  for (ll A = 1; A * A <= N; ++A) {
    if (N % A == 0) {
      ll B = N / A;
      int F = max(calc_digit(A), calc_digit(B));
      res = min(res, F);
    }
  }
  cout << res << endl;
}
