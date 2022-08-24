// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/946407/dohatsu/C++
#include<iostream>
using namespace std;
int t[10001];
int n,m,a,b,ans=0;
int main(){
  cin>>n;
  for(int i=0;i<n;i++)cin>>t[i];
  cin>>m;
  for(int i=0;i<m;i++){
    cin>>a;
    t[n]=a;
    for(b=0;t[b]!=a;b++);
    if(b!=n)ans++;
  }
  cout<<ans<<endl;
  return 0;
}
