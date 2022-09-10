// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/2398068/beet/C++
#include<iostream>
using namespace std;
#define int long long
signed main(){
  int n;
  cin>>n;
  int a[n];
  for(int i=0;i<n;i++) cin>>a[i];
  for(int i=0;i<n;i++){
    cout<<"node "<<i+1<<": key = "<<a[i]<<", ";
    if(i) cout<<"parent key = "<<a[(i-1)/2]<<", ";
    if(i*2+1<n) cout<<"left key = "<<a[i*2+1]<<", ";
    if(i*2+2<n) cout<<"right key = "<<a[i*2+2]<<", ";
    cout<<endl;
  }
  return 0;
}
