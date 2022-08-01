// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/3742598/kyopro_friends/C
#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#define max(p,q)((p)>(q)?(p):(q))

int a[1010];

int main(){
  int n;
  scanf("%d",&n);
  double d[9],df=0;
  for(int i=0;i<n;i++){scanf("%d",a+i);}
  for(int i=0;i<n;i++){
    int t;
    scanf("%d",&t);
    for(int j=1;j<=3;j++) {d[j]+=pow(abs(a[i]-t),j);}
    df=max(df,abs(a[i]-t));
  }
  for(int j=1;j<=3;j++){printf("%f\n",pow(d[j],1.0/j));}
  printf("%f\n",df);
}
