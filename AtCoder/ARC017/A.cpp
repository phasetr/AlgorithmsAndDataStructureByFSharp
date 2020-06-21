// https://atcoder.jp/contests/arc017/tasks/arc017_1
// https://qiita.com/drken/items/a14e9af0ca2d857dad23#%E5%95%8F%E9%A1%8C-1-%E7%B4%A0%E6%95%B0%E5%88%A4%E5%AE%9A
#include <iostream>
using namespace std;

bool is_prime(long long N) {
  if (N == 1) return false;
  for (long long i = 2; i * i <= N; ++i) {
    if (N % i == 0) return false;
  }
  return true;
}

int main() {
  long long N;
  cin >> N;
  if (is_prime(N))
    cout << "Yes" << endl;
  else
    cout << "No" << endl;
}
