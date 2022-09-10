// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/3751547/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>

typedef struct node{
  struct node*oya;
  struct node*ko[2];
  int val;
}node;

int push(node*v,node*oya,int dir,int val){
  if(!v){
    v=(node*)calloc(1,sizeof(node));
    (*v).oya=oya;
    (*v).val=val;
    (*oya).ko[dir]=v;
  }else{
    int d=(*v).val<val;
    push((*v).ko[d],v,d,val);
  }
}

node*find(node*v,int val){
  if(!v)return 0;
  if((*v).val==val)return v;
  int d=(*v).val<val;
  return find((*v).ko[d],val);
}
node*nxt(node*v){
  if((*v).ko[0])return nxt((*v).ko[0]);
  if((*v).ko[1])return nxt((*v).ko[1]);
  return v;
}

void del(node*v){
  if(!v)return;
  if((*v).ko[0]){
    if((*v).ko[1]){
      node*nnn=nxt((*v).ko[1]);
      (*v).val=(*nnn).val;
      del(nnn);
    }else{
      if((*(*v).oya).ko[0]==v)(*(*v).oya).ko[0]=(*v).ko[0];
      else (*(*v).oya).ko[1]=(*v).ko[0];
      (*(*v).ko[0]).oya=(*v).oya;
      free(v);
    }
  }else{
    if((*v).ko[1]){
      if((*(*v).oya).ko[0]==v)(*(*v).oya).ko[0]=(*v).ko[1];
      else (*(*v).oya).ko[1]=(*v).ko[1];
      (*(*v).ko[1]).oya=(*v).oya;
      free(v);
    }else{
      if((*(*v).oya).ko[0]==v)(*(*v).oya).ko[0]=0;
      else (*(*v).oya).ko[1]=0;
      free(v);
    }
  }
}

void f(node*v,int mode){
  if(!v)return;
  if(mode==0)printf(" %d",(*v).val);
  f((*v).ko[0],mode);
  if(mode==1)printf(" %d",(*v).val);
  f((*v).ko[1],mode);
}

node root;
int main(){
  int n;
  scanf("%d",&n);
  while(n--){
    char s[10];
    scanf("%s",s);
    if(s[0]=='p'){
      f(root.ko[0],1);
      puts("");
      f(root.ko[0],0);
      puts("");
    }else if(s[0]=='i'){
      int t;
      scanf("%d",&t);
      push(root.ko[0],&root,0,t);
    }else if(s[0]=='f'){
      int t;
      scanf("%d",&t);
      puts(find(root.ko[0],t)?"yes":"no");
    }else if(s[0]=='d'){
      int t;
      scanf("%d",&t);
      del(find(root.ko[0],t));
    }
  }
}
