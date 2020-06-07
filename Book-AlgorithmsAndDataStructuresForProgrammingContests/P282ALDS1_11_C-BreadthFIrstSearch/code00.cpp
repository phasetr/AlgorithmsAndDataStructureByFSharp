#include <iostream>
#include <queue>
using namespace std;

static const int N = 100;
static const int INFTY = (1 << 21);

int n, M[N][N];
int d[N];  // 距離で訪問状態（color）を管理する

// 幅優先探索：breadth first search
void bfs(int s) {
  queue<int> q;  // 標準ライブラリの queue を使用
  q.push(s);

  for (int i = 0; i < n; i++) d[i] = INFTY;
  d[s] = 0;

  int u;
  while (!q.empty()) {
    u = q.front();
    q.pop();
    for (int v = 0; v < n; v++) {
      if (M[u][v] == 0) continue;
      if (d[v] != INFTY) continue;
      d[v] = d[u] + 1;
      q.push(v);
    }
  }
  for (int i = 0; i < n; i++) {
    cout << i + 1 << " " << ((d[i] == INFTY) ? (-1) : d[i]) << endl;
  }
}

int main() {
  int u, k, v;

  cin >> n;
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) M[i][j] = 0;
  }

  for (int i = 0; i < n; i++) {
    cin >> u >> k;
    u--;  // convert to 0 origin
    for (int j = 0; j < k; j++) {
      cin >> v;
      v--;  // convert to 0 origin
      M[u][v] = 1;
    }
  }

  bfs(0);

  return 0;
}