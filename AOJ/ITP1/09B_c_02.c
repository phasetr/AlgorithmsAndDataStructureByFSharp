// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/879854/Raven38/C
#include <stdio.h>
#include <string.h>

int main(){
  char s[258] = {}, tmp[258] = {};
  int m, h, i, l;
  while(scanf("%s", s) && s[0] != '-'){
    scanf("%d", &m);
    while(m--){
      scanf("%d", &h);
      strcpy(tmp, s + h);
      s[h] = '\0';
      strcat(tmp, s);
      strcpy(s, tmp);
    }
    puts(s);
  }
  return 0;
}
