// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/3743281/kyopro_friends/C
#include <stdio.h>

int a[2000010];
int l,r;

int main(){
  int n;
  scanf("%d",&n);
  while(n--){
    char s[99];
    scanf("%s",s);
    if(s[0]=='i')scanf("%d",a+r++);
    else if(s[6]==0){
      int t;
      scanf("%d",&t);
      for(int idx=r-1;idx>=l;idx--)if(a[idx]==t){
          a[idx]=-1;
          break;
        }
    }else if(s[6]=='F')while(a[--r]==-1);
    else while(a[l++]==-1);
  }
  int f=0;
  for(int i=r-1;i>=l;i--)if(a[i]!=-1)printf(f++?" %d":"%d",a[i]);
  puts("");
}
