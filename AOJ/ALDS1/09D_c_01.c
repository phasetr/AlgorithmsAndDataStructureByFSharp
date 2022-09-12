// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/6677254/Charles98/C
#include <stdio.h>
#include <stdlib.h>
#define MAX_NUM 200000

int cmp(const void *a, const void *b){
  int lhs = *(const int *) a;
  int rhs = *(const int *) b;

  if (lhs < rhs) return -1;
  if (lhs > rhs) return 1;
  return 0;
}

int main(void){
  int i, j, p, tmp, n;
  int a[MAX_NUM + 1];

  scanf("%d", &n);
  for (i = 0; i < n; ++i) scanf("%d", &a[i]);

  qsort(a, n, sizeof(int), cmp);

  a[n] = a[0];

  for (i = 1; i < n; ++i) {
    j = i; p = j / 2;
    while (p > 0 && a[j] > a[p]) {
      tmp = a[j];
      a[j] = a[p];
      a[p] = tmp;
      j = p;
      p = j / 2;
    }
  }

  printf("%d", a[1]);
  for (i = 2; i <= n; ++i) printf(" %d", a[i]);
  printf("\n");

  return 0;
}
