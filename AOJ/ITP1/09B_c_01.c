// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/3742533/kyopro_friends/C
#include <stdio.h>
#include <string.h>
char s[210];
int main(){
  while(scanf("%s",s),strcmp(s,"-")){
    int m;
    scanf("%d",&m);
    int c = 0;
    while(m--){
      int t;
      scanf("%d",&t);
      c += t;
    }
    c %= strlen(s);
    printf("%s",s+c);
    s[c] = 0;
    puts(s);
  }
}
