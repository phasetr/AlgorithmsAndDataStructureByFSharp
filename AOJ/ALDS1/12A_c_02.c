// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/1438329/s1210207/C
#include <stdio.h>
#include <limits.h>

#define MAX_N 100
#define INF INT_MAX/2
#define min(a,b) (a < b ? a : b)

int prim(int,int[MAX_N][MAX_N]);

int main(){
  int n,i,j,a[MAX_N][MAX_N];
  scanf("%d",&n);
  for(i = 0 ; i < n ; i++){
    for(j = 0 ; j < n ; j++){
      scanf("%d",&a[i][j]);
    }
  }
  printf("%d\n",prim(n,a));
  return 0;
}

int prim(int n,int a[MAX_N][MAX_N]){
  int i,v,cost[MAX_N],used[MAX_N],res = 0;
  for(i = 0 ; i < n ; i++){
    cost[i] = INF;
    used[i] = 0;
  }

  cost[0] = 0;
  while(1){
    v = -1;
    for(i = 0 ; i < n ; i++){
      if(!used[i] && (v == -1 || cost[i] < cost[v])){
        v = i;
      }
    }
    if(v == -1){ break; }
    used[v] = 1;
    res += cost[v];
    for(i = 0 ; i < n ; i++){
      if(a[v][i] == -1){ continue; }
      cost[i] = min(cost[i],a[v][i]);
    }
  }
  return res;
}
