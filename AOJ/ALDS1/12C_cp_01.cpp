// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/692822/climpet/C++
#include <cstdio>
#include <queue>
#include <algorithm>
#include <utility>
#include <vector>
#include <functional>
using namespace std;

typedef pair<int,int> pii;

int main(){
  int n;
  scanf("%d", &n);
  vector<vector<pii> > G(n);
  for(int i = 0; i < n; ++i){
    int u, k, v, c;
    scanf("%d%d", &u, &k);
    for(int j = 0; j < k; ++j){
      scanf("%d%d", &v, &c);
      G[u].push_back(pii(c, v));
    }
  }

  vector<int> d(n, 1 << 30);
  d[0] = 0;
  priority_queue<pii,vector<pii>,greater<pii> > pq;
  pq.push(pii(0, 0));
  while(!pq.empty()){
    int c = pq.top().first;
    int u = pq.top().second;
    pq.pop();
    if(d[u] != c){ continue; }
    for(int i = 0; i < G[u].size(); ++i){
      int b = c + G[u][i].first;
      int v = G[u][i].second;
      if(d[v] > b){
        d[v] = b;
        pq.push(pii(b, v));
      }
    }
  }

  for(int i = 0; i < n; ++i){
    printf("%d %d\n", i, d[i]);
  }
}
