#include <iostream>
using namespace std;

static const int N = 50;

int main() {
  int n;
  int F[N];

  cin >> n;

  F[0] = F[1] = 1;
  for (int i = 2; i <= n; i++) F[i] = F[i - 1] + F[i - 2];

  cout << F[n] << endl;

  return 0;
}
