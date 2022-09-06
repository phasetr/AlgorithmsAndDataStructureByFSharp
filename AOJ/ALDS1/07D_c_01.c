// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/3751426/kyopro_friends/C
#include <stdio.h>

int n;
int a[50],b[50];
int c=0;
void p(int i){printf(c++?" %d":"%d",b[i]);}

void f(int l,int r){
  if(l==r)return;
  if(l+1==r){
    p(l);
    return;
  }
  //bの[l,r)に存在するもののうち、aの中で最も前にあるものを探す
  int idx=-1;
  for(int i=0;i<n;i++){
    for(int j=l;j<r;j++)if(b[j]==a[i])idx=j;
    if(idx!=-1)break;
  }
  f(l,idx);
  f(idx+1,r);
  p(idx);
}

int main(){
  scanf("%d",&n);
  for(int i=0;i<n;i++)scanf("%d",a+i);
  for(int i=0;i<n;i++)scanf("%d",b+i);
  f(0,n);
  puts("");
}
