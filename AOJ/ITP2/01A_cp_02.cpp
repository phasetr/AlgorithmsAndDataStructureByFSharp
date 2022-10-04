// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/3042477/c7c7/C++
#include <vector>
#include <iostream>
#define r(i,n) for(int i=0;i<n;i++)
using namespace std;

int main(){
  int q;
  vector<int>v;
  cin>>q;
  while(q--){
    int a,b;
    cin>>a;
    if(a!=2)cin>>b;
    if(!a)v.push_back(b);
    else if(a==1)cout<<v[b]<<endl;
    else v.erase(v.end()-1);
  }
}
