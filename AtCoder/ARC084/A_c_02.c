// https://atcoder.jp/contests/abc077/submissions/10323693
#include <stdio.h>
#include <stdlib.h>
//#include <string.h>
//#include <stdbool.h>
//#include <limits.h>
//#include <math.h>

//昇順
int acs(const void *a, const void *b)
{
  return *(int *)a - *(int *)b;
}

int main() {
  int n;
  scanf("%d", &n);
  int a[n], b[n], c[n];
  for (int i=0; i<n; i++)
    scanf("%d", a+i);
  for (int i=0; i<n; i++)
    scanf("%d", b+i);
  for (int i=0; i<n; i++)
    scanf("%d", c+i);
  qsort(a, n, sizeof(int), acs);
  qsort(b, n, sizeof(int), acs);
  qsort(c, n, sizeof(int), acs);
  long ans = 0, sum[n+1];
  int j = 0;
  sum[0] = 0;
  for (int i=0; i<n; i++) {
    while (j<n && a[j]<b[i])
      j++;
    sum[i+1] = sum[i] + j;
  }
  j = 0;
  for (int i=0; i<n; i++) {
    while (j<n && b[j]<c[i]) {
      j++;
    }
    ans += sum[j];
  }
  printf("%ld\n", ans);
  return 0;
}
