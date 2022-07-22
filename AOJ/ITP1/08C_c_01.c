// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/6608068/khagiwara/C
#include <stdio.h>
#include <ctype.h>
int main() {
  int arr[26] = {};
  char c;
  while (scanf("%c", &c) != EOF) {
    if (isalpha(c)) {
      if (isupper(c)) {c = tolower(c);}
      arr[c - 'a']++;
    }
  }
  for (int i = 0; i < 26; i++) {
    printf("%c : %d\n", 'a' + i, arr[i]);
  }
  return 0;
}
