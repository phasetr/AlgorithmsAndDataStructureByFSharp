// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/1285152/kzyKT/C
#include <stdio.h>

int main() {
  int n,a[101],i,j;
  scanf("%d",&n);
  for(i=0; i<n; i++) scanf("%d",&a[i]);
  int cnt=0;
  for(i=0; i<n; i++) {
    for(j=n-1; j>i; j--) {
      if(a[j]<a[j-1]) {
        int tmp=a[j];
        a[j]=a[j-1];
        a[j-1]=tmp;
        cnt++;
      }
    }
  }
  for(i=0; i<n; i++) {
    if(i) printf(" ");
    printf("%d",a[i]);
  }
  printf("\n%d\n",cnt);
  return 0;
}
