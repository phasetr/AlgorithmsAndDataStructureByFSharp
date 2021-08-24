// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_2_B&lang=ja
#include <iostream>
using namespace std;

int selectionSort(int A[], int N) {
  int minj, count;
  count = 0;
  for (int i = 0; i < N - 1; i++) {
    minj = i;
    for (int j = i; j < N; j++) {
      if (A[j] < A[minj]) minj = j;
    }
    swap(A[i], A[minj]);
    if (i != minj) count++;
  }
  return count;
}

int main() {
  int A[100], N, count;
  cin >> N;
  for (int i = 0; i < N; i++) cin >> A[i];
  count = selectionSort(A, N);

  for (int i = 0; i < N; i++) {
    if (i) cout << " ";
    cout << A[i];
  }
  cout << endl;
  cout << count << endl;
  return 0;
}