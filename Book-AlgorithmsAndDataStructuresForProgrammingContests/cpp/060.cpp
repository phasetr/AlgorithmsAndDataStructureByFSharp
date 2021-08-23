// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_2_A&lang=ja
#include <iostream>
using namespace std;

void output(int A[], int N, int count) {
  int i;
  for (i = 0; i < N; i++) {
    if (i) cout << " ";
    cout << A[i];
  }
  cout << endl;
  cout << count << endl;
}

int bubbleSort(int A[], int N) {
  int i, j;
  int count = 0;
  bool flag = 1;
  for (i = 0; flag; i++) {
    flag = 0;
    for (j = N - 1; j >= i + 1; j--) {
      // We need the exact inequality "<" for stability
      if (A[j] < A[j - 1]) {
        swap(A[j], A[j - 1]);
        flag = 1;
        count++;
      }
    }
  }
  return count;
}

int main() {
  int N, i, count;
  int A[100];

  cin >> N;
  for (i = 0; i < N; i++) cin >> A[i];

  count = bubbleSort(A, N);
  output(A, N, count);
  return 0;
}
