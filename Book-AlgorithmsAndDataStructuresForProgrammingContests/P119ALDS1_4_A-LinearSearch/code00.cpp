// self implementation
#include <iostream>
using namespace std;

int main() {
  int S[10000], T[10000];
  int n, q;

  cin >> n;
  for (int i = 0; i < n; i++) scanf("%d", &S[i]);
  cin >> q;
  for (int i = 0; i < q; i++) scanf("%d", &T[i]);

  // cout << n << endl;
  // for (int i = 0; i < n; i++) cout << S[i] << " ";
  // cout << endl;
  // cout << q << endl;
  // for (int i = 0; i < q; i++) cout << T[i] << " ";
  // cout << endl;

  int count = 0;
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < q; j++) {
      if (S[i] == T[j]) {
        count++;
        break;
      }
    }
  }

  cout << count << endl;
  return 0;
}