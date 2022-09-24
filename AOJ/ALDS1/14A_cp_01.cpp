// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/1776938/dohatsu/C++
#include<iostream>
using namespace std;
string n,m;
int main(){
  cin>>n>>m;
  int i=n.find(m);
  while(i!=-1){
    cout<<i<<endl;
    i=n.find(m,i+1);
  }
  return 0;
}
