// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/3751404/kyopro_friends/C
#include <stdio.h>
#define max(p,q)((p)>(q)?(p):(q))

//辺の情報を個別に持つタイプ
int n;
int oya[30];
int ko1[30],ko2[30];

void f(int v,int mode){
  if(mode==0)printf(" %d",v);
  if(ko1[v]!=-1)f(ko1[v],mode);
  if(mode==1)printf(" %d",v);
  if(ko2[v]!=-1)f(ko2[v],mode);
  if(mode==2)printf(" %d",v);
}

int cnt[30];
int main(){
  scanf("%d",&n);
  for(int i=0;i<n;i++)oya[i]=-1;
  for(int i=0;i<n;i++){
    int x,y,z;
    scanf("%d%d%d",&x,&y,&z);
    ko1[x]=y;
    ko2[x]=z;
    oya[y]=x;
    oya[z]=x;
    cnt[y]++;
    cnt[z]++;
  }
  int root;
  for(int i=0;i<n;i++)if(cnt[i]==0)root=i;
  puts("Preorder");
  f(root,0);
  puts("");
  puts("Inorder");
  f(root,1);
  puts("");
  puts("Postorder");
  f(root,2);
  puts("");
}
