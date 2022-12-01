// https://atcoder.jp/contests/abc077/submissions/14715815
#include <stdlib.h>
#include <stdio.h>
#define N 100009
typedef long long LL;
int n,i,a[N],b[N],c[N];LL ans=0;
#define rp for(i=0;i<n;i++)

int up(int*a,int*b){return*(int*)a-*(int*)b;}
int dn(int*a,int*b){return*(int*)b-*(int*)a;}
int compA(int x,int y){return a[y]>=x?1:0;}
int compC(int x,int y){return c[y]<=x?1:0;}
LL BS(int x,int n,int c){
  int O=n,X=-1,mid=n/2;
  while(O-X>1){
    mid=(O+X)/2;
    c?(compA(x,mid)?(O=mid):(X=mid)):(compC(x,mid)?(O=mid):(X=mid));}
  return O;
}

int main(){
  scanf("%d",&n);
  rp scanf("%d",a+i);qsort(a,n,4,up);
  rp scanf("%d",b+i);qsort(b,n,4,up);
  rp scanf("%d",c+i);qsort(c,n,4,dn);
  rp ans+=BS(b[i],n,1)*BS(b[i],n,0);
  printf("%lld",ans);
}
