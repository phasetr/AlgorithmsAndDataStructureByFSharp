// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/3765077/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>

typedef struct node{
  struct node*oya,*ko[2];
  int val,p;
}node;

void rot(node*v,int d){
  node*nnn=v->ko[d];

  v->ko[d]=nnn->ko[d^1];
  if(v->ko[d])v->ko[d]->oya=v;

  v->oya->ko[v->oya->ko[1]==v]=nnn;
  nnn->oya=v->oya;

  nnn->ko[d^1]=v;
  v->oya=nnn;
}
void ins(node*v,node*oya,int dir,int val,int p){
  if(!v){
    v=calloc(1,sizeof(node));
    v->oya=oya;
    v->val=val;
    v->p=p;
    oya->ko[dir]=v;
  }else{
    int d=v->val<val;
    ins(v->ko[d],v,d,val,p);
    if(v->ko[d]->p > v->p)rot(v,d);
  }
}
node*find(node*v,int val){
  if(!v)return 0;
  if(v->val==val)return v;
  return find(v->ko[v->val<val],val);
}
void del(node*v){
  while(v){
    if(v->ko[0]){
      if(v->ko[1])rot(v,v->ko[1]->p > v->ko[0]->p);
      else rot(v,0);
    }else{
      if(v->ko[1])rot(v,1);
      else v=v->oya->ko[v->oya->ko[1]==v]=0;
    }
  }
}

void f(node*v,int mode){
  if(!v)return;
  if(!mode)printf(" %d",v->val);
  f(v->ko[0],mode);
  if(mode)printf(" %d",v->val);
  f(v->ko[1],mode);
}

node root;
int main(){
  int n;
  scanf("%d",&n);

  while(n--){
    int t,p;
    char s[10];
    scanf("%s",s);
    if(s[0]=='p'){
      f(root.ko[0],1);puts("");
      f(root.ko[0],0);puts("");
    }else if(s[0]=='i'){
      scanf("%d%d",&t,&p);
      ins(root.ko[0],&root,0,t,p);
    }else if(s[0]=='f'){
      scanf("%d",&t);
      puts(find(root.ko[0],t)?"yes":"no");
    }else{
      scanf("%d",&t);
      del(find(root.ko[0],t));
    }
  }
}
