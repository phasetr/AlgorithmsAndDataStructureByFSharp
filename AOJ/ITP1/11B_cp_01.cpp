// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B
#include<iostream>
using namespace std;

int main(){
  int y[7];
  int x[6][6]={{0,3,5,2,4,0},{4,0,1,6,0,3},{2,6,0,0,1,5},{5,1,0,0,6,2},{3,0,6,1,0,4},{0,4,2,5,3,0}};
  int a,b,c,d;
  int q;
  cin>>y[1]>>y[2]>>y[3]>>y[4]>>y[5]>>y[6];
  cin>>q;
  for(int i=0;i<q;i++){
    cin>>a>>b;
    for(int j=1;j<=6;j++){
      if(a==y[j]){
        c=j;
      }
      if(b==y[j]){
        d=j;
      }
    }
    cout<<y[x[c-1][d-1]]<<endl;
  }
  return 0;
}
