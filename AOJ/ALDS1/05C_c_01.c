// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/3750388/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#define PI 3.14159265358979323846

double x[1<<12|10];
double y[1<<12|10];

int main(){
  int n;
  scanf("%d",&n);
  if(n==0){
    puts("0 0\n100 0");
    return 0;
  }
  x[0]= 33.33333333,y[0]= 0.00000000;
  x[1]= 50.00000000,y[1]=28.86751346;
  x[2]= 66.66666667,y[2]= 0.00000000;
  x[3]=100.00000000,y[3]= 0.00000000;

  for(int k=1;k<n;k++){
    int m=1<<(2*k);
    for(int i=0;i<m;i++){
      x[i]/=3;
      y[i]/=3;
      x[m+i]=cos(PI/3)*x[i]-sin(PI/3)*y[i]+100.0/3;
      y[m+i]=sin(PI/3)*x[i]+cos(PI/3)*y[i];
      x[2*m+i]=cos(-PI/3)*(x[i]-100.0/3)-sin(-PI/3)*y[i]+200.0/3;
      y[2*m+i]=sin(-PI/3)*(x[i]-100.0/3)+cos(-PI/3)*y[i];
      x[3*m+i]=x[i]+200.0/3;
      y[3*m+i]=y[i];
    }
  }
  puts("0 0");
  for(int i=0;i<1<<(2*n);i++)printf("%f %f\n",x[i],y[i]);
}
