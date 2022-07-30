// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/2823842/bal4u/C
#include <stdio.h>
#include <math.h>

int s[1002];

#define gc() getchar_unlocked()
int in() {
  int n = 0, c = gc();
  do n = 10*n + (c & 0xf), c = gc();
  while (c >= '0');
  return n;
}

int main() {
  int n, i, is;
  double m, fs, a;
  while ((n = in())) {
    is = 0; for (i = 0; i < n; i++) is += s[i] = in();
    m = (double)is/n;
    fs = 0; for (i = 0; i < n; i++) {
      a = s[i]-m;
      fs += a*a;
    }
    printf("%.8lf\n", sqrt(fs/n));
  }
  return 0;
}
