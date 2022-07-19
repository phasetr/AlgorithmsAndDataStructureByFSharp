// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/2703480/atjh16/C++
#include <iostream>
#include <cmath>
using namespace std;

const int INF = -100;
int k, r, c;
int a[8] = { INF, INF, INF, INF, INF, INF, INF, INF };
bool b[8] = { 0, 0, 0, 0, 0, 0, 0, 0 };

bool check() {
  for (int i = 0; i < 7; i++) {
    for (int j = i + 1; j < 8; j++)
      if (a[i] == a[j] || j - i == abs(a[i] - a[j]))
        return false;
  }
  return true;
}

void set(int i) {
  if (i == 8) {
    if (check()) {
      for (int i = 0; i < 8; i++) {
        for (int j = 0; j < 8; j++) {
          if (a[i] == j)
            cout << "Q";
          else
            cout << ".";
        }
        cout << endl;
      }
    }
    return;
  }

  if (b[i]){
    set(i + 1);
  } else {
    for (int j = 0; j < 8; j++) {
      a[i] = j;
      set(i + 1);
    }
  }
}

int main(){
  cin >> k;
  for (int i = 0; i < k; i++) {
    cin >> r >> c;
    a[r] = c;
    b[r] = 1;
  }
  set(0);
  return 0;
}
