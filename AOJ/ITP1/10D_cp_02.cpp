// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/3042428/c7c7/C++
#include <iostream>
#include <cmath>
#define r(i,n) for(int i=0;i<n;i++)
using namespace std;

int main(){
  int n;
  cin>>n;
  double a[n],b[n],A=0,B=0,C=0,D=0;
  r(i,n)cin>>a[i];
  r(i,n)cin>>b[i];
  r(i,n){
    A+=abs(a[i]-b[i]);
    B+=abs(a[i]-b[i])*abs(a[i]-b[i]);
    D+=abs(a[i]-b[i])*abs(a[i]-b[i])*abs(a[i]-b[i]);
    C=max(C,abs(a[i]-b[i]));
  }
  B=sqrt(B);
  D=pow(D,1.0/3);
  printf("%.11f\n",A);
  printf("%.11f\n",B);
  printf("%.11f\n",D);
  printf("%.11f\n",C);
}
