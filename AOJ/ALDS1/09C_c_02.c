// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/3752056/kyopro_friends/C
#include <stdio.h>
#define ll long long

//*
// プラキュー（二分ヒープ）（最低限バージョン）
// int PQhikaku(int i,int j);//jの方が優先度が高いならtrueを返す
int PQhikaku(ll*heap,int i,int j){return heap[i]<heap[j];}
void heap_utod(ll*heap,int n){
  if(2*n>heap[0])return;
  int rflag=(2*n+1<=heap[0])&&(PQhikaku(heap,2*n,2*n+1));
  if(PQhikaku(heap,n,2*n+rflag)){
    ll temp=heap[2*n+rflag];
    heap[2*n+rflag]=heap[n];
    heap[n]=temp;
    heap_utod(heap,2*n+rflag);
  }
}
void heap_dtou(ll*heap,int n){
  if(n==1||PQhikaku(heap,n,n/2))return;
  ll temp=heap[n];
  heap[n]=heap[n/2];
  heap[n/2]=temp;
  heap_dtou(heap,n/2);
}
ll PQpop(ll*heap){
  ll rr=heap[1];
  heap[1]=heap[heap[0]--];
  heap_utod(heap,1);
  return rr;
}
void PQpush(ll*heap,ll n){
  heap[++heap[0]]=n;
  heap_dtou(heap,heap[0]);
}
//*/

ll a[2000010];

int main(){
  char s[10];
  while(scanf("%s",s),s[2]!='d'){
    if(s[0]=='i'){
      int t;
      scanf("%d",&t);
      PQpush(a,t);
    }else{
      printf("%lld\n",PQpop(a));
    }
  }
}
