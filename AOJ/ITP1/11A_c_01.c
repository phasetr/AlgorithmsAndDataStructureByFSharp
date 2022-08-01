// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/1294569/Iceman/C
#include<stdio.h>
int i,N[7],T,F,R,t;
char S[105];
int main()
{
  for(i=1;i<=6;i++)scanf("%d",N+i);
  gets(S);
  gets(S);
  for(T=1,F=2,R=3,i=0;S[i];i++){
    switch(S[i]){
    case 'N':t=T,T=F,F=7-t;break;
    case 'E':t=R,R=T,T=7-t;break;
    case 'S':t=F,F=T,T=7-t;break;
    case 'W':t=T,T=R,R=7-t;break;
    }
  }
  printf("%d\n",N[T]);
  return 0;
}

