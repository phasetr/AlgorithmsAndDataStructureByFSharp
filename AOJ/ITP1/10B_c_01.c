// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/6481985/vjudge2/C
#include<stdio.h>
#include<math.h>
int main(){
  int a,b,c;
  double area,o,p,h,x;
  scanf("%d%d%d",&a,&b,&c);
  x = (c*3.141592653589793)/180;
  area = (a*b*sin(x))/2.0;
  h = b*sin(x);
  o = (sqrt(a*a+b*b-2*a*b*cos(x)));
  p = a+b+o;
  printf("%.8lf\n%.8lf\n%.8lf\n",area,p,h);
  return 0;
}
