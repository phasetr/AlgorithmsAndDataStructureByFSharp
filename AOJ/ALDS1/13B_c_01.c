// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/3752706/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>

int a[10];
int fact[10]={1,1,2,6,24,120,720,5040,40320};

int dp[362880];
void swap(int i,int j){
  int t=a[i];
  a[i]=a[j];
  a[j]=t;
}

int f(){
  int ans=0,b=0;
  for(int i=8;i>=0;i--){
    ans+=__builtin_popcount(b&((1<<a[i])-1))*fact[8-i];
    b|=1<<a[i];
  }
  return ans;
}
void g(int n){
  int b=0;
  for(int i=0;i<9;i++)a[i]=i;
  for(int i=0;i<9;i++){
    int x=n/fact[8-i];
    n%=fact[8-i];
    for(int j=x;j>0;j--)swap(i+j,i+j-1);
  }
}

int que[363000],quecnt;
void check(int p,int k){
  int x=f();
  if(!dp[x]){
    dp[x]=k+1;
    que[quecnt++]=x*10+p;
  }
}
int calc(){
  for(int i=0;i<quecnt;i++){
    int x=que[i]/10;
    int p=que[i]%10;
    if(x==0)return dp[x]-1;
    g(x);
    if(p  <6)swap(p,p+3),check(p+3,dp[x]),swap(p,p+3);
    if(p  >2)swap(p,p-3),check(p-3,dp[x]),swap(p,p-3);
    if(p%3<2)swap(p,p+1),check(p+1,dp[x]),swap(p,p+1);
    if(p%3>0)swap(p,p-1),check(p-1,dp[x]),swap(p,p-1);
  }
  return -1;
}

int main(){
  int p;
  for(int i=0;i<9;i++){
    int t;
    scanf("%d",&t);
    if(t)a[i]=t-1;
    else{
      a[i]=8;
      p=i;
    }
  }
  check(p,0);
  printf("%d\n",calc());
}
