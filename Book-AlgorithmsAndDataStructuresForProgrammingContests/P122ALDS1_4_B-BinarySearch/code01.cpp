// Using STL, lower_bound
#include <algorithm>
#include <iostream>
using namespace std;

int main() {
  int A[1000000], n;

  cin >> n;
  for (int i = 0; i < n; i++) scanf("%d", &A[i]);

  int q, k, sum = 0;
  cin >> q;
  for (int i = 0; i < q; i++) {
    scanf("%d", &k);
    if (*lower_bound(A, A + n, k) == k) sum++;
  }

  cout << sum << endl;

  return 0;
}