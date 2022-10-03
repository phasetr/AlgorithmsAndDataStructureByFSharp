// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/950600/secure9361/C
#include <stdio.h>

int extgcd(int a, int b, int* x, int* y) {
  int d = a;
  if (b != 0) {
    d = extgcd(b, a % b, y, x);
    *y -= (a / b) * *x;
  } else {
    *x = 1; *y = 0;
  }
  return d;
}

int main(void) {
  int a, b, x, y;
  scanf("%d %d\n", &a, &b);

  extgcd(a, b, &x, &y);
  printf("%d %d\n", x, y);

  return 0;
}
