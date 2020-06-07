#include <algorithm>
#include <iostream>
using namespace std;

// Find a maximum value
int findMaximum(int A[], int l, int r) {
  int m = (l + r) / 2;  // Divide
  if (l == r - 1) {
    return A[l];
  } else {
    int u = findMaximum(A, l, m);  // Solve a subproblem
    int v = findMaximum(A, m, r);  // Solve a subproblem
    int x = max(u, v);             // Counquer
  }
  return 0;
}

int main() { return 0; }