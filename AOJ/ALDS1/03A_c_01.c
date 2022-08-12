// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/3743134/kyopro_friends/C
#include<stdio.h>
#include<stdlib.h>

int a[110];
int cnt;
char s[99];

int main(){
  while(~scanf("%s",s)){
    switch(*s){
    case'+':a[cnt-2]+=a[cnt-1];cnt--;break;
    case'*':a[cnt-2]*=a[cnt-1];cnt--;break;
    case'-':a[cnt-2]-=a[cnt-1];cnt--;break;
    case'/':a[cnt-2]/=a[cnt-1];cnt--;break;
    default:a[cnt++]=atoi(s);
    }
  }
  printf("%d\n",a[0]);
}
