// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/2307734/dohatsu/C++
#include <cstdio>
#include <map>

int A[1000000];

int main(){
  int n,m,ans=0;
  scanf("%d",&n);
  for(int i=0;i<n;i++){
    int a;
    scanf("%d",&a);
    A[a%1000000]=1;
  }
  scanf("%d",&m);
  for(int i=0;i<m;i++){
    int a;
    scanf("%d",&a);
    ans+=A[a%1000000];
  }
  printf("%d\n",ans);
  return 0;
}
