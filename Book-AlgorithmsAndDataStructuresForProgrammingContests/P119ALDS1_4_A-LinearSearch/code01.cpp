// Use the sentinel
#include <iostream>
using namespace std;

int linearSeach(int S[], int n, int key) {
  int i = 0;
  S[n] = key;
  while (S[i] != key) i++;

  // If i = n, the target found is the sentinel,
  // so return false
  return i != n;
}

int main() {
  int i, n, S[10000 + 1], q, key, sum = 0;

  scanf("%d", &n);
  for (i = 0; i < n; i++) scanf("%d", &S[i]);

  scanf("%d", &q);
  for (i = 0; i < q; i++) {
    scanf("%d", &key);
    if (linearSeach(S, n, key)) sum++;
  }
  printf("%d\n", sum);

  return 0;
}