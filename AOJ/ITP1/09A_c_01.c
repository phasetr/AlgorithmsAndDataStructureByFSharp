// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/6779318/vjudge2/C
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
int main(void)
{
  int count=0;
  char s[13],t[1005],st[12]="END_OF_TEXT";
  scanf("%s",s);
  while(1){
    scanf("%s",t);
    if(strcmp(t,st)==0) {break;}
    int d=strcasecmp(s,t);
    if(d==0) {count++;}
  }
  printf("%d\n",count);
  return 0;
}
