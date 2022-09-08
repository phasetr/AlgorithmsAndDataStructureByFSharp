// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/1872637/s1230151/C++
#include <iostream>
using namespace std;
struct node{
  node* l;
  node* r;
  node* p;
  int key;
};

node L;
node* nil=&L;
node* t=nil;

bool find(node* a,int t){
  if(a->key==t)return 1;
  if(a==nil)return 0;
  if(a->key<t)return find(a->r,t);
  else return find(a->l,t);
}

void insert(node* a){
  node* y=nil;
  node* x=t;
  while(x!=nil){
    y=x;
    if(a->key<x->key)x=x->l;
    else x=x->r;
  }
  a->p=y;
  if(y==nil)t=a;
  else if(a->key<(y->key))y->l=a;
  else y->r=a;
}

void pri(node* b,int a){
  if(b==nil)return;
  if(!a)cout<<" "<<b->key;
  pri(b->l,a);
  if(a)cout<<" "<<b->key;
  pri(b->r,a);
}

int main(){
  int n,a;
  string s;
  cin>>n;

  for(int i=0;i<n;i++){
    cin>>s;
    if(s[0]=='i'){
      cin>>a;
      node* b=(node *)malloc(sizeof(node));
      b->l=nil;
      b->r=nil;
      b->key=a;
      insert(b);
    }
    else if(s[0]=='f'){
      cin>>a;
      if(find(t,a))cout<<"yes"<<endl;
      else cout<<"no"<<endl;
    }
    else{
      pri(t,1);
      cout<<endl;
      pri(t,0);
      cout<<endl;
    }
  }
  return 0;
}
