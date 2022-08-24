// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/3750192/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define ll long long
#define rep(i,l,r)for(ll i=(l);i<(r);i++)

int d[1<<25];
int f(char*s){
  int ret=1;
  for(int i=0;s[i];i++){
    switch(s[i]){
      case 'A':ret=ret*4+0;break;
      case 'G':ret=ret*4+1;break;
      case 'C':ret=ret*4+2;break;
      case 'T':ret=ret*4+3;break;
    }
  }
  return ret;
}
int main(){
  int n;
  scanf("%d",&n);
  while(n--){
    char p[10],q[20];
    scanf("%s%s",p,q);
    if(p[0]=='i')d[f(q)]=1;
    else puts(d[f(q)]?"yes":"no");
  }
}
