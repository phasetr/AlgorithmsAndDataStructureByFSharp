// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/4260407/SSRS/C++
#include <iostream>
#include <vector>
using namespace std;
int main(){
  int r, c;
  cin >> r >> c;
  vector<vector<int> > a(r + 1, vector<int>(c + 1, 0));
  for (int i = 0; i < r; i++){
    for (int j = 0; j < c; j++){
      cin >> a[i][j];
      a[i][c] += a[i][j];
      a[r][j] += a[i][j];
      a[r][c] += a[i][j];
    }
  }
  for (int i = 0; i <= r; i++){
    for (int j = 0; j <= c; j++){
      cout << a[i][j];
      if (j < c){
        cout << ' ';
      }
    }
    cout << endl;
  }
}
