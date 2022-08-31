// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/3750917/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define ll long long
#define rep(i,l,r)for(ll i=(l);i<(r);i++)
#define min(p,q)((p)<(q)?(p):(q))
int upll(const void*a, const void*b){return*(ll*)a<*(ll*)b?-1:*(ll*)a>*(ll*)b?1:0;}
void sortup(ll*a,int n){qsort(a,n,sizeof(ll),upll);}

//座圧(破壊的)
int cocomp(ll*a,int n){
  //0～cnt-1に圧縮
  ll*b=(ll*)malloc(sizeof(ll)*n);
  memcpy(b,a,sizeof(ll)*n);
  sortup(b,n);
  int cnt=1;
  rep(r,1,n)if(b[r]!=b[cnt-1])b[cnt++]=b[r];
  rep(i,0,n){
    int l=0,r=cnt;
    while(r-l>1){int m=(l+r)/2;if(b[m]>a[i])r=m;else l=m;}
    a[i]=l;
  }
  free(b);
  return cnt;
}

ll a[1010],b[1010];
ll sum[1010],mm[1010],len[1010],cnt;

int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++){
    scanf("%d",a+i);
    b[i]=a[i];
  }
  cocomp(b,n);

  for(int i=0;i<n;i++)if(b[i]!=-1){
    int tsum=0;
    int tlen=0;
    int tmm=1e9;
    int crr=i;
    do{
      tsum+=a[crr];
      tmm=min(tmm,a[crr]);
      tlen++;
      int temp=b[crr];
      b[crr]=-1;
      crr=temp;
    }while(crr!=i);
    sum[cnt]=tsum;
    mm[cnt]=tmm;
    len[cnt]=tlen;
    cnt++;
  }

  int ans=1e9;
  rep(i,0,cnt){
    //mm[i]を使う
    int tans=0;
    rep(j,0,cnt)tans+=min((sum[j]-mm[j])+(len[j]-1)*mm[j],(sum[j]-mm[j])+(len[j]-1)*mm[i]+(mm[i]+mm[j])*2);
    ans=min(ans,tans);
  }

  printf("%d\n",ans);
}
