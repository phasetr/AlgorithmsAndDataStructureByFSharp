// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/3154322/mikeCAT/C
#include <stdio.h>
#include <math.h>

int main(void) {
  int n;
  while (scanf("%d", &n) == 1 && n != 0) {
    double s[1024];
    int i;
    double average = 0, sd = 0;
    for (i = 0; i < n; i++) {
      if (scanf("%lf", &s[i]) != 1) {return 1;}
      average += s[i];
    }
    average /= n;
    for (i = 0; i < n; i++) {
      sd += (s[i] - average) * (s[i] - average);
    }
    printf("%.15f\n", sqrt(sd / n));
  }
  return 0;
}
