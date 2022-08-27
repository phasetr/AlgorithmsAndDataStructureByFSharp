// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/1820936/kzyKT/C++
#include <cstdio>
#include <complex>
#include <iostream>
using namespace std;
typedef complex<double> P;
double toRad(double agl) {return agl*M_PI/180.0;}
P rotate(P a, double r) {
  return P(a.real()*cos(r)-a.imag()*sin(r),a.real()*sin(r)+a.imag()*cos(r));
}
int n;
void dfs(P l, P r,int k) {
  if(k==n) {
    printf("%.10f %.10f\n",l.real(),l.imag());
    return;
  }
  P s=l+(r-l)*0.333333333333333,t=l+(r-l)*0.666666666666666;
  P u=s+rotate(t-s,toRad(60));
  dfs(l,s,k+1);
  dfs(s,u,k+1);
  dfs(u,t,k+1);
  dfs(t,r,k+1);
}
int main() {
  cin >> n;
  dfs(0,100,0);
  printf("%.10f %.10f\n",100.0,0.0);
  return 0;
}
