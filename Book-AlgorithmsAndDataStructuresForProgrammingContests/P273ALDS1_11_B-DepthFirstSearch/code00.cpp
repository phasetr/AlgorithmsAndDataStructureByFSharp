#include <iostream>
using namespace std;

static const int N = 100;
static const int WHITE = 0;
static const int GRAY = 1;
static const int BLACK = 2;

int n, M[N][N];
int color[N], tt;
int d[N];  // discovery time
int f[N];  // find time

// Depth first search
void dfs_visit(int u) {
  int v;
  color[u] = GRAY;
  d[u] = ++tt;  // first visit
  for (v = 0; v < n; v++) {
    if (M[u][v] == 0) continue;
    if (color[v] == WHITE) {
      dfs_visit(v);
    }
  }
  color[u] = BLACK;
  f[u] = ++tt;  // finish visit
}

void dfs() {
  int u;
  for (u = 0; u < n; u++) color[u] = WHITE;
  tt = 0;

  for (u = 0; u < n; u++) {
    // DF search: the initial point `u` is an unvisited point
    if (color[u] == WHITE) dfs_visit(u);
  }
  for (u = 0; u < n; u++) {
    printf("%d %d %d\n", u + 1, d[u], f[u]);
  }
}

int main() {
  int u, v, k, i, j;

  scanf("%d", &n);
  for (i = 0; i < n; i++) {
    for (j = 0; j < n; j++) M[i][j] = 0;
  }

  for (i = 0; i < n; i++) {
    scanf("%d %d", &u, &k);
    u--;  // convert to 0 origin
    for (j = 0; j < k; j++) {
      scanf("%d", &v);
      v--;  // convert to 0 origin
      M[u][v] = 1;
    }
  }

  dfs();

  return 0;
}
