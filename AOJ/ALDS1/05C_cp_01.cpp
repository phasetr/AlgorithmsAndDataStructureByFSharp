// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/1279145/imulan/C++
#include <cmath>
#include <cstdio>
#include <iostream>
using namespace std;

typedef struct{
  double x;
  double y;
}point;

void Printp(point a){
  printf("%lf %lf\n", a.x, a.y);
}

void koch(int d, point p, point q){
  if(d==0) return;

  point s, u, t;
  //calculation
  s.x=(2*p.x+q.x)/3.0;
  s.y=(2*p.y+q.y)/3.0;
  t.x=(p.x+2*q.x)/3.0;
  t.y=(p.y+2*q.y)/3.0;

  double ang=M_PI*60/180.0;
  u.x=(t.x-s.x)*cos(ang) - (t.y-s.y)*sin(ang) +s.x;
  u.y=(t.x-s.x)*sin(ang) + (t.y-s.y)*cos(ang) +s.y;

  koch(d-1, p, s);
  Printp(s);
  koch(d-1, s, u);
  Printp(u);
  koch(d-1, u, t);
  Printp(t);
  koch(d-1, t, q);
}

int main(){
  int n;
  scanf(" %d", &n);

  point s1,s2;
  s1.x=0; s1.y=0;
  s2.x=100; s2.y=0;

  Printp(s1);
  koch(n, s1, s2);
  Printp(s2);
}
