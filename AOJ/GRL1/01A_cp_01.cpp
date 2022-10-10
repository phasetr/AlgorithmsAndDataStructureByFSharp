// https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/894016/ei1333/C++
#include<cstdio>
#include<algorithm>
#include<queue>
#include<vector>
#include<map>
using namespace std;
typedef pair< int, int > Pi;
const int INF = 1 << 30;
struct edge: vector< Pi > {
  void add_edge(int to, int cost){
    push_back(Pi(to,cost));
  }
} info[100000];
int hoge[100000];

void bfs(const int& st, const int& V){
  fill_n( hoge, V, INF);
  queue< int > que;
  que.push(st);
  hoge[st] = 0;
  while(!que.empty()){
    int p = que.front();
    que.pop();
    for(int i = 0 ; i < info[p].size() ; i++){
      int cost = info[p][i].second;
      int to = info[p][i].first;
      if( cost + hoge[p] < hoge[to]){
        que.push(to);
        hoge[to] = cost + hoge[p];
      }
    }
  }
}

int main(){
  int V, E, r;
  scanf("%d %d %d", &V, &E, &r);
  for(int i = 0; i < E; i++){
    int s, t, d;
    scanf("%d %d %d", &s, &t, &d);
    info[s].add_edge( t, d);
  }
  bfs(r,V);
  for(int i = 0 ; i < V ; i++ ){
    if( hoge[i] == INF ) puts("INF");
    else printf("%d\n", hoge[i]);
  }
}
