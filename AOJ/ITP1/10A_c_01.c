// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/2823771/bal4u/C
#include <stdio.h>
#include <math.h>

int main(){
  double x1, y1, x2, y2;
  scanf("%lf%lf%lf%lf", &x1, &y1, &x2, &y2);
  printf("%.8lf\n", hypot(x1-x2, y1-y2));
  return 0;
}
