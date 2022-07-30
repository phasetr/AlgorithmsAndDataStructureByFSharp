// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/1993738/naoto172/C++
#include <stdio.h>
#include <math.h>

using namespace std;

int main(){
  int n;
  double students[1000] = {0},sum,m,div;

  while(true){
    scanf("%d",&n);
    if(n == 0) break;
    div = sum = 0;
    for(int i = 0; i < n; i++){
      scanf("%lf",&students[i]);
      sum += students[i];
    }
    m = sum/n;
    for(int i = 0; i < n;i++){
      div += (students[i] - m)*(students[i] - m);
      students[i] = 0;
    }
    printf("%.8lf\n",sqrt(div/n));
  }
}
