// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/3742544/kyopro_friends/C
#include <stdio.h>
#include <string.h>
char s[200],t[200];
int main(){
  int a=0,b=0;
  int n;
  scanf("%d",&n);
  while(n--){
    scanf(" %s%s",s,t);
    int flag=strcmp(s,t);
    if (flag>0)  {a+=3;}
    if (flag<0)  {b+=3;}
    if (flag==0) {a++,b++;}
  }
  printf("%d %d\n",a,b);
}
