// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/3742557/kyopro_friends/C
#include <stdio.h>
#include <string.h>
char s[1010];
char r[1010];
int main(){
  scanf("%s",s);
  int n;
  scanf("%d",&n);
  while(n--){
    char t[10];
    int a,b;
    char x;
    scanf("%s%d%d",t,&a,&b);
    switch(t[2]){
    case 'p':
      scanf("%s",r);
      for(int i=a;i<=b;i++){s[i]=r[i-a];}
      break;
    case 'v':
      memcpy(r,s+a,b-a+1);
      for(int i=a;i<=b;i++){s[b-(i-a)]=r[i-a];}
      break;
    case 'i':
      x=s[b+1];
      s[b+1]=0;
      puts(s+a);
      s[b+1]=x;
      break;
    }
  }
}
