// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/3752244/kyopro_friends/C
#include <stdio.h>
#define ll long long
#define rep(i,l,r)for(ll i=(l);i<(r);i++)

//union-find
#define UFLIMIT (1<<17)
int unicnt[UFLIMIT+10];//正ならcnt、非正なら根のindex
void ufinit(int n){rep(i,0,n)unicnt[i]=1;}
int root(int x){return unicnt[x]<=0?-(unicnt[x]=-root(-unicnt[x])):x;}
int same(int x,int y){return root(x)==root(y);}
void uni(int x,int y){if((x=root(x))==(y=root(y)))return;if(unicnt[x]<unicnt[y]){int t=x;x=y;y=t;}unicnt[x]+=unicnt[y];unicnt[y]=-x;}
#undef UFLIMIT

int main(){
  int n,m;
  scanf("%d%d",&n,&m);
  ufinit(n);
  while(m--){
    int a,b;
    scanf("%d%d",&a,&b);
    uni(a,b);
  }
  scanf("%d",&m);
  while(m--){
    int a,b;
    scanf("%d%d",&a,&b);
    puts(same(a,b)?"yes":"no");
  }
}
