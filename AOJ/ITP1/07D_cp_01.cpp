// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/2568668/syl659/C++
#include <iostream>
using namespace std;

int main(){
  int n,m,l;
  cin >> n >> m >> l;

  long long int a[100][100], b[100][100];
  for(int i=0; i<n; i++){
    for(int j=0; j<m; j++){
      cin >> a[i][j];
    }
  }
  for(int i=0; i<m; i++){
    for(int j=0; j<l; j++){
      cin >> b[i][j];
    }
  }
  for(int i=0; i<n; i++){
    for(int j=0; j<l; j++){
      long long int elem=0;
      for(int k=0; k<m; k++){
        elem += a[i][k]*b[k][j];
      }
      if(j==0) cout << elem;
      else cout << " " << elem;
    }
    cout << endl;
  }
  return 0;
}
