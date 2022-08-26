// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2172139/c7c7/C++
#include <iostream>
using namespace std;
int n,a[20],m,i,x;
int dfs(int y,int p){
  if(p==0)return 1;
  if(y>=n)return 0;
  int q=dfs(y+1,p)||dfs(y+1,p-a[y]);
  return q;
}
int main(){
  for(cin>>n;i<n;i++)cin>>a[i];
  for(cin>>m,i=0;i<m;i++){
    cin>>x;
    if(dfs(0,x))cout<<"yes"<<endl;
    else cout<<"no"<<endl;
  }
}
