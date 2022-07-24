// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/6608152/khagiwara/C
#include <stdio.h>
#include <string.h>
int main() {
  char s[101], s2[201], p[101];
  scanf("%s", s);
  scanf("%s", p);
  strcpy(s2, s);
  strcat(s2, s);
  printf("%s\n", (strstr(s2, p) ? "Yes" : "No"));

  return 0;
}
