// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/3071895/vjudge2/C++
#include <cstdio>
#include <iostream>
using namespace std;
struct point{
  int a,b;
  point *l,*r,*pa;
  point(){l=r=pa=NULL;}
  point(int aa,int bb):a(aa),b(bb){l=r=pa=NULL;};
};
point *root;
point *rightRotate(point *t){
  point *s=t->l;
  t->l=s->r;
  s->r=t;
  return s;
}
point *leftRotate(point *t){
  point *s=t->r;
  t->r=s->l;
  s->l=t;
  return s;
}
point* insert(point *p,int a,int b){
  if(p==NULL)return new point(a,b);
  if(a==p->a)return p;
  if(a<p->a){
    p->l=insert(p->l,a,b);
    if(p->b<p->l->b)
      p=rightRotate(p);
  }else{
    p->r=insert(p->r,a,b);
    if(p->b<p->r->b)
      p=leftRotate(p);
  }return p;
}
point *_del(point *p, int a);
point *del(point *p,int a){
  if(p==NULL)return NULL;
  if(a<p->a)p->l=del(p->l,a);
  else if(a>p->a)p->r=del(p->r,a);
  else return _del(p,a);
  return p;
}
point *_del(point *p, int a){
  if(p->l==NULL&&p->r==NULL)return NULL;
  else if(p->l==NULL)p=leftRotate(p);
  else if(p->r==NULL)p=rightRotate(p);
  else{
    if(p->l->b>p->r->b)p=rightRotate(p);
    else p=leftRotate(p);
  }return del(p,a);
}
bool find(int a){
  point *p=root;
  while(p){
    if(a==p->a)return 1;
    if(a>p->a)p=p->r;
    else p=p->l;
  }
  return 0;
}
void dfs1(point *p){
  if(!p)return;
  dfs1(p->l);
  printf(" %d",p->a);
  dfs1(p->r);
}
void dfs2(point *p){
  if(!p)return;
  printf(" %d",p->a);
  dfs2(p->l);
  dfs2(p->r);
}
int main(){
  ios::sync_with_stdio(false);cin.tie(0);cout.tie(0);
  int T;cin>>T;
  int ta,tb;
  string s;
  while(cin>>s){
    if(s=="insert"){
      cin>>ta>>tb;
      root=insert(root,ta,tb);
    }else if(s=="find"){
      cin>>ta;
      if(find(ta))printf("yes\n");
      else printf("no\n");
    }else if(s=="print"){
      dfs1(root);
      printf("\n");
      dfs2(root);
      printf("\n");
    }else if(s=="delete"){
      cin>>ta;
      root=del(root,ta);
    }
  }
  return 0;
}
