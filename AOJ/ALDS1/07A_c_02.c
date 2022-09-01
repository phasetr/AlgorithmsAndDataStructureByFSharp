// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/3751066/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>
#define ll long long
#define rep(i,l,r)for(ll i=(l);i<(r);i++)

//辺の情報を個別に持つタイプ
typedef struct edge{ll s,g;}E;
typedef struct graph{
  int vcnt,ecnt;
  E  e[200010];//適宜変える
  int id[100010];//適宜変える
}G;

int esort(const void*a,const void*b){
  E*p=(E*)a,*q=(E*)b;
  if((*p).s<(*q).s)return -1;
  if((*p).s>(*q).s)return  1;
  return 0;
}

int cnt[100010];
G g;
void readgraph(){
  //適宜変える
  ll n;
  scanf("%lld",&n);
  int m=0;
  rep(i,0,n){
    ll x,y,k;
    scanf("%lld%lld",&x,&k);
    while(k--){
      scanf("%lld",&y);
      cnt[y]++;
      g.e[m].s=x;
      g.e[m].g=y;
      m++;
      g.e[m].s=y;
      g.e[m].g=x;
      m++;
    }
  }
  g.vcnt=n;
  g.ecnt=m;
  qsort(g.e,g.ecnt,sizeof(E),esort);

  int p=0;
  rep(i,0,g.vcnt){
    while(p<g.ecnt&&g.e[p].s<i)p++;
    g.id[i]=p;
  }
  g.id[g.vcnt]=g.ecnt;//番兵
}

//dfs
int a[100010];
void dfs(int v,int pre){
  rep(i,g.id[v],g.id[v+1]){
    if(g.e[i].g!=pre){
      //hoge
      a[g.e[i].g]=a[v]+1;
      dfs(g.e[i].g,v);
    }
  }
}

int main(){
  readgraph();
  int r;
  rep(i,0,g.vcnt)if(cnt[i]==0)r=i;
  dfs(r,-1);
  rep(i,0,g.vcnt){
    int t=-1;
    rep(j,g.id[i],g.id[i+1])if(a[g.e[j].g]<a[i]){
      t=g.e[j].g;
      break;
    }

    printf("node %lld: parent = %d, depth = %d, ",i,t,a[i]);

    if(i==r)printf("root, ");
    else if(g.id[i]+1==g.id[i+1])printf("leaf, ");
    else printf("internal node, ");

    printf("[");
    int flag=0;
    rep(j,g.id[i],g.id[i+1])if(a[g.e[j].g]>a[i])printf(flag++?", %lld":"%lld",g.e[j].g);
    puts("]");
  }
}
