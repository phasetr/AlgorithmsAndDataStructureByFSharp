// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/1049315/TKT29/C
#include <stdio.h>
#include <string.h>

int main(void){
  int i,n = 0;
  char w[11], t[1001];
  scanf("%s", w);
  do {
    scanf("%s",t);
    if(!strcmp(t,"END_OF_TEXT")) {break;}
    for(i=0;t[i]!='\0';i++) {if(t[i]<91) {t[i] += 32;}}
    if( !strcmp(w,t) ) {n++;}
  } while(1);
  printf("%d\n",n);
  return 0;
}
