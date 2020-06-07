#include <algorithm>
#include <cstdio>
#include <iostream>
#include <queue>
using namespace std;
int main() {
  int n, q, t;
  string name;
  queue<pair<string, int>> Q;

  pair<string, int> u;
  int elaps = 0, a;

  cin >> n >> q;

  for (int i = 0; i < n; i++) {
    cin >> name >> t;
    Q.push(make_pair(name, t));
  }

  while (!Q.empty()) {
    u = Q.front();
    Q.pop();
    a = min(u.second, q);
    u.second -= a;
    elaps += a;
    if (u.second > 0) {
      Q.push(u);
    } else {
      cout << u.first << " " << elaps << endl;
    }
  }

  return 0;
}