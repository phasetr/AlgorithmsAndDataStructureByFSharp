// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/3751458/kyopro_friends/C
#include <stdio.h>

int cnt=1;
int oya[500010];
int ko[2][500010];
int val[500010];

void f(int v,int mode){
  if(mode==0)printf(" %d",val[v]);
  if(ko[0][v])f(ko[0][v],mode);
  if(mode==1)printf(" %d",val[v]);
  if(ko[1][v])f(ko[1][v],mode);
  if(mode==2)printf(" %d",val[v]);
}
void push(int v,int va){
  //初回
  if(cnt==1){
    val[cnt]=va;
    cnt++;
    return;
  }
  if(ko[val[v]<va][v])push(ko[val[v]<va][v],va);
  else{
    ko[val[v]<va][v]=cnt;
    oya[cnt]=v;
    val[cnt]=va;
    cnt++;
  }
}

int find(int v,int va){
  if(val[v]==va)return 1;
  if(ko[val[v]<va][v])return find(ko[val[v]<va][v],va);
  return 0;
}

int main(){
  int q;
  scanf("%d",&q);
  while(q--){
    char s[10];
    scanf("%s",s);
    if(s[0]=='p'){
      f(1,1);
      puts("");
      f(1,0);
      puts("");
    }else if(s[0]=='i'){
      int t;
      scanf("%d",&t);
      push(1,t);
    }else{
      int t;
      scanf("%d",&t);
      puts(find(1,t)?"yes":"no");
    }
  }
}
