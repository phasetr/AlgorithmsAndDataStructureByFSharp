// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/1600824/E869120/C++
#include<iostream>
#include<algorithm>
using namespace std;

int b[1000];

int main(){
    int y[2][6];
    int x[6][6]={{0,3,5,2,4,0},{4,0,1,6,0,3},{2,6,0,0,1,5},{5,1,0,0,6,2},{3,0,6,1,0,4},{0,4,2,5,3,0}};
    int a[6];
    int MAX;

    for(int i=0;i<2;i++){
      for(int j=0;j<6;j++){
        cin>>y[i][j];
        b[y[i][j]] ++;
      }
    }
    for(int i=0;i<1000;i++){
      MAX=max(MAX,b[i]);
    }
    if(MAX>=6){
      cout<<"Yes"<<endl;
      goto Exit;
    }
    for(int i=0;i<6;i++){
      for(int j=0;j<6;j++){
        if(y[0][j]==y[1][i]){
          a[i]=j;
        }
      }
    }
    if(x[a[0]][a[1]]==a[2]+1){
      cout<<"Yes"<<endl;
      goto Exit;
    }
    cout<<"No"<<endl;
Exit:;
    return 0;
}
