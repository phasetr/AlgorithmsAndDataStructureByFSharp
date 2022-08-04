// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/1620420/E869120/C++
#include<iostream>
using namespace std;
int change[24][6] = {
  {0,1,2,3,4,5},
  {0,2,4,1,3,5},
  {0,4,3,2,1,5},
  {0,3,1,4,2,5},
  {5,2,1,4,3,0},
  {5,4,2,3,1,0},
  {5,3,4,1,2,0},
  {5,1,3,2,4,0},
  {1,2,0,5,3,4},
  {1,0,3,2,5,4},
  {1,3,5,0,2,4},
  {1,5,2,3,0,4},
  {4,0,2,3,5,1},
  {4,3,0,5,2,1},
  {4,5,3,2,0,1},
  {4,2,5,0,3,1},
  {2,0,1,4,5,3},
  {2,4,0,5,1,3},
  {2,5,4,1,0,3},
  {2,1,5,0,4,3},
  {3,1,0,5,4,2},
  {3,0,4,1,5,2},
  {3,4,5,0,1,2},
  {3,5,1,4,0,2}
};
int n, x[100][6][24];
int main() {
  cin >> n;
  for (int i = 0; i < n; i++) {
    cin >> x[i][0][0] >> x[i][1][0] >> x[i][2][0] >> x[i][3][0] >> x[i][4][0] >> x[i][5][0];
    for (int j = 0; j < 24; j++) {
      for (int k = 0; k < 6; k++) {
        x[i][k][j] = x[i][change[j][k]][0];
      }
    }
  }
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
      if (i != j) {
        for (int k = 0; k < 24; k++) {
          for (int l = 0; l < 24; l++) {
            for (int m = 0; m < 6; m++) {
              if (x[i][m][k] != x[j][m][l]) {
                goto A;
              }
            }
            goto TRUE;
          A:;
          }
        }
      }
    }
  }
  goto FALSE;
TRUE:;
  cout << "No" << endl; goto Exit;
FALSE:; cout << "Yes" << endl;
Exit:;
  return 0;
}
