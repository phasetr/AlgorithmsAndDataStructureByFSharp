// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/894031/ei1333/C++
#include<iostream>
using namespace std;
int main(){
  int N;
  bool info[100][100] = {{}};
  cin >> N;
  for(int i = 0; i < N; i++){
    int u, k;
    cin >> u >> k;
    while(k--){
      int v;
      cin >> v;
      info[u - 1][v - 1] = true;
    }
  }
  for(int i = 0; i < N; i++){
    for(int j = 0; j < N; j++){
      cout << info[i][j] << (j + 1 == N ? '\n' : ' ');
    }
  }
}
