// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/3751398/kyopro_friends/C
#include <stdio.h>
#define max(p,q)((p)>(q)?(p):(q))

//辺の情報を個別に持つタイプ
int n;
int oya[30];
int ko1[30],ko2[30];

int dep(int k){
  if(oya[k]==-1)return 0;
  return dep(oya[k])+1;
}

int hai(int k){
  int ans=0;
  if(ko1[k]!=-1)ans=max(ans,hai(ko1[k])+1);
  if(ko2[k]!=-1)ans=max(ans,hai(ko2[k])+1);
  return ans;
}

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
  }
  for(int i=0;i<n;i++){
    printf("node %d: parent = %d, sibling = %d, degree = %d, ",i,oya[i],oya[i]==-1?-1:ko1[oya[i]]+ko2[oya[i]]-i,(ko1[i]!=-1)+(ko2[i]!=-1));
    int d=dep(i),h=hai(i);
    printf("depth = %d, height = %d, %s",d,h,d==0?"root":h==0?"leaf":"internal node");
    puts("");
  }
}
