// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/6024853/hiro1729/C
#include <stdio.h>
#define MAX 1000
int main(void){
  int n;
  scanf("%d", &n);
  double p[n];
  double q[n + 1];
  double c[n + 1][n + 1];
  double d[n + 1];
  for (int i = 0; i < n; i++) scanf("%lf", &p[i]);
  for (int i = 0; i < n + 1; i++) scanf("%lf", &q[i]);
  c[0][0] = q[0];
  d[0] = p[0] + q[0];
  for (int i = 1; i < n + 1; i++) {
    c[i][i] = q[i];
    c[i - 1][i] = p[i - 1] + (q[i - 1] + q[i]) * 2;
    d[i] = d[i - 1] + p[i] + q[i];
  }
  double s, t;
  for (int i = 1; i < n; i++) {
    for (int j = 0; j < n - i; j++) {
      s = c[j][j] + c[j + 1][i + j + 1];
      for (int k = j; k < i + j; k++) {
        t = c[j][k + 1] + c[k + 2][i + j + 1];
        if (s > t)
          s = t;
      }
      c[j][i + j + 1] = s + d[i + j] - d[j - 1] + q[i + j + 1];
    }
  }
  printf("%.12lf\n", c[0][n]);
  return 0;
}
