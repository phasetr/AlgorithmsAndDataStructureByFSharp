// https://qiita.com/drken/items/a14e9af0ca2d857dad23#問題-2-約数列挙
#include <algorithm>
#include <iostream>
#include <vector>
using namespace std;

using ll = long long;

vector<ll> enumDivisors(ll N) {
  vector<ll> res;
  for (ll i = 1; i * i <= N; ++i) {
    if (N % i == 0) {
      res.push_back(i);
      // 重複しないならば i の相方である N/i も push
      // （N=25, i=5 などの場合を除外する）
      // もしくは突っ込むだけ突っ込んで後で一意化する
      if (N / i != i) res.push_back(N / i);
    }
  }
  // 小さい順に並び替える
  sort(res.begin(), res.end());
  return res;
}

int main() {
  ll N;
  cin >> N;
  const auto &res = enumDivisors(N);
  for (int i = 0; i < res.size(); ++i) cout << res[i] << " ";
  cout << endl;
}