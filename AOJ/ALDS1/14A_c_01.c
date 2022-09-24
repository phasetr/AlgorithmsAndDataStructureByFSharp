// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/1998294/fwii8609/C
#include <stdio.h>
#include <string.h>

int main(int argc, char** argv){
  char t[1001];
  char p[1001];
  int m, n;
  int i;

  scanf("%s %s", t, p);
  m = strlen(t);
  n = strlen(p);
  for (i = 0; i <= m - n; ++i){
    if (strncmp(&t[i], p, n) == 0) printf("%d\n", i);
  }

  return 0;
}
