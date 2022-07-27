// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2826323/bal4u/C
#include <stdio.h>

char str[1005];
char p[1005];

int main() {
  int q, a, b;
  char op[10], *x, *y, c;

  scanf("%s%d", str, &q);
  while (q--) {
    scanf("%s%d%d", op, &a, &b);
    if (op[2] == 'i') {
      // print
      b++, c = *(str+b), *(str+b) = 0, puts(str+a), *(str+b) = c;
    } else if (op[2] == 'v') {
      // reverse
      x = str+a, y = str+b;
      while (x < y) {
        c = *x, *x = *y, *y = c;
        x++, y--;
      }
    } else {
      // replace
      scanf("%s", p);
      x = str+a, y = p;
      while (*y) *x++ = *y++;
    }
  }
  return 0;
}
