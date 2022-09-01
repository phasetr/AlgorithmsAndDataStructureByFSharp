// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/413887/s1180008/C
#include <stdio.h>
int N;
int parent[100001];
char isLeaf[100001];

int calcDepth(int i) {
  if(parent[i] == -1) return 0;
  return calcDepth(parent[i]) + 1;
}

int main() {
  int i,j;
  scanf("%d", &N);
  for(i = 0; i < N; ++i) {
    parent[i] = -1;
    isLeaf[i] = 1;
  }
  for(i = 0; i < N; ++i) {
    int id, k;
    scanf("%d %d", &id, &k);
    while(k--) {
      int c;
      scanf("%d", &c);
      parent[c] = id;
      isLeaf[id] = 0;
    }
  }
  for(i = 0; i < N; ++i) {
    int depth = calcDepth(i);
    printf("node %d: parent = %d, depth = %d, ", i, parent[i], depth);
    if(isLeaf[i]) {
      printf("leaf\n");
    } else if(depth == 0) {
      printf("root\n");
    } else {
      printf("internal node\n");
    }
  }
  return 0;
}

