// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/1066500/imulan/C++
#include <cstdio>
#include <cmath>

int main(){
  int n, x[100], y[100];

  scanf(" %d", &n);
  for(int i=0; i<n; ++i) {scanf(" %d", &x[i]);}
  for(int i=0; i<n; ++i) {scanf(" %d", &y[i]);}

  for(int p=1; p<=3; ++p){
    double d=0;
    for(int i=0; i<n; ++i) {d += pow( fabs(x[i]-y[i]), p);}
    printf("%lf\n", pow(d,1.0/p));
  }

  double max=0;
  for(int i=0; i<n; ++i) {if(max < fabs(x[i]-y[i])) {max = fabs(x[i]-y[i]);}}
  printf("%lf\n", max);
  return 0;
}
