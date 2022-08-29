// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/3750439/kyopro_friends/C
#include <stdio.h>

int b[10010];
int main(){
  int n;
  scanf("%d",&n);
  while(n--){
    int t;
    scanf("%d",&t);
    b[t]++;
  }
  int f=0;
  for(int i=0;i<10010;i++)if(b[i]--)printf(f++?" %d":"%d",i--);
  puts("");
}
