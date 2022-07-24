// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1049259/TKT29/C
#include <stdio.h>
int main(void){
  char s[101],p[101];
  int i,j,sn=0,pn=0,t;

  scanf("%s %s",s,p);
  //文字数カウント
  while(s[sn] != '\0') {sn++;}
  while(p[pn] != '\0') {pn++;}

  for(i=0;i<sn;i++){
    t=1;
    for(j=0;j<pn;j++) {if(s[(i+j)%sn] != p[j]) t=0;}
    if(t) {break;}
  }

  if (t) {printf("Yes\n");}
  else {printf("No\n");}

  return 0;
}
