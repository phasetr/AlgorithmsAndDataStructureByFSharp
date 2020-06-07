#include <iostream>
using namespace std;
static const int MAX = 100000;
typedef long long llong;

int n, k;
llong T[MAX];

int check(llong P) {
  int i = 0;
  for (int j = 0; j < k; j++) {
    llong s = 0;
    while (s + T[i] <= P) {
      s += T[i];
      i++;
      if (i == n) return n;
    }
  }
  return i;
}

int solve() {
  llong left = 0;
  llong right = 100000 * 10000;
  llong mid;
  while (right - left > 1) {
    mid = (left + right) / 2;
    int v = check(mid);  // mid == P を決めて何個積めるか

    // v >= n なら荷物を積める
    if (v >= n)
      right = mid;
    else
      left = mid;
  }

  return right;
}

int main() {
  cin >> n >> k;
  for (int i = 0; i < n; i++) scanf("%lld", &T[i]);
  llong ans = solve();
  cout << ans << endl;
  return 0;
}
