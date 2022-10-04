// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/3020878/kazuma8128/C
#include <stdio.h>

int A[200000];

int main(void){
  int q, com, x, it = 0;
  scanf("%d", &q);
  while (q--) {
    scanf("%d", &com);
    if (com == 0) {
      scanf("%d", &x);
      A[it++] = x;
    }
    else if (com == 1) {
      scanf("%d", &x);
      printf("%d\n", A[x]);
    }
    else {
      --it;
    }
  }
  return 0;
}
