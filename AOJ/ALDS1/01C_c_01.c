// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/3743040/kyopro_friends/C
#include<stdio.h>

int f(int n){
  for(int i=2;i*i<=n;i++){if(n%i==0){return 0;}}
  return 1;
}

int main(){
  int n;
  scanf("%d",&n);
  int ans=0;
  while(n--){
    int t;
    scanf("%d",&t);
    ans+=f(t);
  }
  printf("%d\n",ans);
}
