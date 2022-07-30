// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/3742580/kyopro_friends/C
#include<stdio.h>
#include<math.h>
int a[1010];

int main(){
  int n;
  while(scanf("%d",&n),n){
    double s=0;
    for(int i=0;i<n;i++){
      scanf("%d",a+i);
      s+=a[i];
    }
    s/=n;
    double ans=0;
    for (int i=0;i<n;i++) {ans+=(a[i]-s)*(a[i]-s);}
    printf("%f\n",sqrt(ans/n));
  }
}
