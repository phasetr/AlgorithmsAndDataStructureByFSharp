// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/5256956/vjudge2/C
#include<stdio.h>
#define MAX 10000

int c[MAX+1] = {0};

int main(){
  int n, i, max = 0;
  scanf("%d",&n);
  int a[n], b[n];
  for (i = 0; i < n; i++){
    scanf("%d",&a[i]);
    c[a[i]]++;
    if (a[i] > max)
    {
      max = a[i];
    }
  }
  for (i = 1; i <= max; i++){
    c[i] =  c[i] + c[i - 1];
  }
  for (i = n-1; i >= 0; i--){
    b[--c[a[i]]] = a[i];
  }
  for (i = 0; i < n; i++){
    if(i){ printf(" "); }
    printf("%d",b[i]);
  }
  printf("\n");
  return 0;
}
