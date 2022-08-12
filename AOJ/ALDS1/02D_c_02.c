// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/1285524/kzyKT/C
#include <stdio.h>

int main() {
  int n,a[1000001],g[20],i,j,k,cnt=0;
  scanf("%d",&n);
  for(i=0; i<n; i++) {scanf("%d",&a[i]);}
  int m=0,x=1;
  for(i=0; x<=n; i++) {
    g[i]=x;
    x=x*3+1;
    m++;
  }
  for(k=m-1; k>=0; k--) {
    for(i=g[k]; i<n; i++) {
      int v=a[i];
      j=i-g[k];
      while(j>=0 && a[j]>v) {
        a[j+g[k]]=a[j];
        j=j-g[k];
        cnt++;
      }
      a[j+g[k]]=v;
    }
  }
  printf("%d\n",m);
  for(i=m-1; i>=0; i--) {
    printf("%d",g[i]);
    if(i) printf(" ");
  }
  printf("\n%d\n",cnt);
  for(i=0; i<n; i++) {printf("%d\n",a[i]);}
  return 0;
}
