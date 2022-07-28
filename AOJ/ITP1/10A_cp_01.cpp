// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/1993636/naoto172/C++
#include <stdio.h>
#include <math.h>
using namespace std;

int main(){
  double x1,y1,x2,y2;
  scanf("%lf %lf %lf %lf",&x1,&y1,&x2,&y2);
  printf("%.8lf\n",sqrt((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2)));
}
