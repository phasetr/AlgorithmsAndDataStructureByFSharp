// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/1527088/dohatsu/C++
#include <cstdio>
using namespace std;

struct node{
  int lc;
  int rc;
  int key;
  void init(int a){
    lc=rc=-1;
    key=a;
  }
};

#define bstN 600000
struct bst{
  int size;
  node t[bstN];
  void init(){
    size=0;
  }
  void insert(int v){
    int i=0;
    while(i<size){
      int& child=(v<t[i].key?t[i].lc:t[i].rc);
      if(child==-1)child=size;
      i=child;
    }
    t[size++].init(v);
  }
  void preord(int pos){
    if(pos==-1||pos==size)return;
    preord(t[pos].lc);
    printf(" %d",t[pos].key);
    preord(t[pos].rc);
  }
  void inord(int pos){
    if(pos==-1||pos==size)return;
    printf(" %d",t[pos].key);
    inord(t[pos].lc);
    inord(t[pos].rc);
  }
};

bst T;
int main(){
  T.init();
  int n,a;
  char str[100];
  scanf("%d",&n);

  while(n--){
    scanf("%s",str);
    if(str[0]=='i'){
      scanf("%d",&a);
      T.insert(a);
    }else{
      T.preord(0);
      printf("\n");
      T.inord(0);
      printf("\n");
    }
  }
  return 0;
}
