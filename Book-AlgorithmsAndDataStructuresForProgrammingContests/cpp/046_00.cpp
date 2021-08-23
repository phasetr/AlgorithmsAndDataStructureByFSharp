// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_D&lang=ja
#include <iostream>
using namespace std;
static const int N = 200000;

int main() {
  int R[N], n;
  cin >> n;

  for (int i = 0; i < n; i++) cin >> R[i];

  // IMPORTANT: if we set maxValue = 0 and the gain has minus sign, we will get
  // a wrong answer.
  int maxValue = -200000;
  for (int i = 0; i < n; i++) {
    for (int j = i + 1; j < n; j++) {
      maxValue = max(maxValue, R[j] - R[i]);
    }
  }

  cout << maxValue << endl;
}
