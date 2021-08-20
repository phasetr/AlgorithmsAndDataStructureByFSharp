// P040 TOP3
#include <algorithm>
#include <iostream>
#include <string>
using namespace std;

int main() {
  int n = 10;
  int s[10];

  for (int i = 0; i < n; i++) {
    cin >> s[i];
  }

  // To sort we must include algorithm
  std::sort(s, s + n, std::greater<int>());
  cout << s[0] << " " << s[1] << " " << s[2] << endl;

  return 0;
}
