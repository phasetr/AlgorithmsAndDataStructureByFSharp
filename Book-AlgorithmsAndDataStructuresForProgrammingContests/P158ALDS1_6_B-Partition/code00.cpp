#include <iostream>
using namespace std;

static const int MAX = 100000;

int partition(int A[], int n, int p, int r) {
  int x, i, t;
  x = A[r];
  i = p - 1;
  for (int j = p; j < r; j++) {
    if (A[j] <= x) {
      i++;
      swap(A[i], A[j]);
    }
  }
  swap(A[i + 1], A[r]);
  return i + 1;
}

int main() {
  int i, n, q, A[MAX];

  scanf("%d", &n);
  for (i = 0; i < n; i++) scanf("%d", &A[i]);

  q = partition(A, n, 0, n - 1);

  for (i = 0; i < n; i++) {
    if (i) printf(" ");
    if (i == q) printf("[");
    printf("%d", A[i]);
    if (i == q) printf("]");
  }
  printf("\n");

  return 0;
}
