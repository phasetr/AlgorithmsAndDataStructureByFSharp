// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/881394/s1210207/C++
#include <iostream>
#include <algorithm>

using namespace std;

#define MAX 100
#define INF (1<<29)
#define rep(i,n) for(int i = 0 ; i < n ; i++)

int main(){
  int n;
  int d[MAX][MAX];

  fill(d[0],d[MAX],INF);

  cin >> n;
  rep(i,n){
    int u,k;
    cin >> u >> k;
    rep(j,k){
      int v,c;
      cin >> v >> c;
      d[u][v] = c;
    }
  }

  d[0][0] = 0;
  rep(k,n){
    rep(i,n){
      rep(j,n){
        d[i][j] = min(d[i][j],d[i][k] + d[k][j]);
      }
    }
  }

  rep(i,n){
    cout << i << " " << d[0][i] << endl;
  }

  return 0;
}
