// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/749606/ei1333/C++
#include<cstdio>
#include<cmath>
int main(){
  int n;
  while(scanf("%d",&n) && n){
    int s[1000]={},sum=0;
    for(int i=0;i<n;i++){
      scanf("%d",&s[i]);
      sum += s[i];
    }
    double m = (double)sum / (double)n,ssum=0;
    for(int i=0;i<n;i++) ssum += pow((s[i]-m),2);
    printf("%.7f\n",sqrt(ssum/(double)n));
  }
}
