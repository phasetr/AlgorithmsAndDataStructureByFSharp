#include <algorithm>
#include <iostream>
using namespace std;
static const int MAX = 200000;

int main() {
  int R[MAX], n;
  cin >> n;
  for (int i = 0; i < n; i++) cin >> R[i];

  // IMPORTANT: set sufficiently small number!
  int maxv = -2000000000;
  int minv = R[0];

  for (int i = 1; i < n; i++) {
    // In fact, mathematically thinking, we calculate the max value by a
    // "telescope method". Hence we can suppress one loop.
    maxv = max(maxv, R[i] - minv);
    minv = min(minv, R[i]);
  }

  cout << maxv << endl;

  return 0;
}
