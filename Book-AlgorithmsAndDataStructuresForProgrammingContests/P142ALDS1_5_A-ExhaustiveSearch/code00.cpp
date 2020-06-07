#include <iostream>
using namespace std;

// A recursive function subtracting an element from the input value M
int solve(int A[], int n, int i, int m) {
  if (m == 0) return 1;
  if (i >= n) return 0;
  // need memoize
  int res = solve(A, n, i + 1, m) || solve(A, n, i + 1, m - A[i]);
  return res;
}

int main() {
  int n, q, A[2000], M;

  scanf("%d", &n);
  for (int i = 0; i < n; i++) scanf("%d", &A[i]);
  scanf("%d", &q);
  for (int i = 0; i < q; i++) {
    scanf("%d", &M);
    if (solve(A, n, 0, M)) {
      printf("yes\n");
    } else {
      printf("no\n");
    }
  }

  return 0;
}