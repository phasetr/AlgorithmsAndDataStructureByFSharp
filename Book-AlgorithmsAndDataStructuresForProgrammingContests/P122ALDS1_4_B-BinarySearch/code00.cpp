#include <iostream>
using namespace std;

bool binarySearch(int A[], int n, int key) {
  int left = 0;
  int right = n;
  int mid;

  while (left < right) {
    mid = (left + right) / 2;

    if (key == A[mid]) return true;

    if (key > A[mid]) {
      left = mid + 1;
    } else if (key < A[mid]) {
      right = mid;
    }
  }

  return false;
}

int main() {
  int i, n, q, key, count = 0;
  int S[1000000];

  cin >> n;
  for (i = 0; i < n; i++) scanf("%d", &S[i]);
  cin >> q;
  for (i = 0; i < q; i++) {
    scanf("%d", &key);
    if (binarySearch(S, n, key)) count++;
  }

  cout << count << endl;

  return 0;
}