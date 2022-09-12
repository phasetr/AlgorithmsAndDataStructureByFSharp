// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/5250019/__rito__/C++
#include <cstdio>
#include <cstring>
#include <algorithm>
using namespace std;
const int MAX_N = 200000;
int heap[MAX_N+1];
void solve(int N){
  sort(heap+1,heap+N+1);
  for (int n = 1; n <= N; ++n){
    int i = n-1, par = i/2;
    while(par >= 1){
      swap(heap[i],heap[par]);
      i = par, par = i/2;
    }
    swap(heap[1],heap[n]);
  }
}
int main(){
  int N;
  scanf("%d",&N);
  for (int i = 1; i <= N; ++i) scanf("%d",heap+i);
  solve(N);
  for (int i = 1; i <= N; ++i) printf("%d%c",heap[i]," \n"[i==N]);
}
