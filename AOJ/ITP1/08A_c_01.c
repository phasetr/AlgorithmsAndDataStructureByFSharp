// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/6605657/khagiwara/C
#include <stdio.h>
#include <ctype.h>
int main() {
  char c;
  while ((c = getchar()) != EOF) {
    if (islower(c)) { c = toupper(c); }
    else { if (isupper(c)) { c = tolower(c); } }
    printf("%c", c);
  }
  return 0;
}
