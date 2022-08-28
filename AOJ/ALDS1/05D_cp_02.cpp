// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/1677155/E869120/C++
#include<iostream>
#include<algorithm>
using namespace std;

#define MAX_N 1000000

int bit[MAX_N];
int a[MAX_N], b[MAX_N];
int n;

void add(int p) {
  while (p <= n) {
    bit[p] += 1;
    p += p&-p;
  }
}
int sum1(int p) {
  int sum2 = 0;
  while (p > 0) {
    sum2 += bit[p];
    p -= p&-p;
  }
  return sum2;
}
int sum(int l, int r) {
  return sum1(r - 1) - sum1(l - 1);
}

int main() {
  cin >> n;
  for (int i = 1; i <= n; i++) {
    cin >> a[i];
    b[i] = a[i];
  }
  sort(b + 1, b + n + 1);
  long long res = 0LL;
  for (int i = 1; i <= n; i++) {
    int v = lower_bound(b + 1, b + n + 1, a[i]) - b;
    add(v);
    res += sum(v + 1, n + 1);
  }
  cout << res << endl;
  return 0;
}
