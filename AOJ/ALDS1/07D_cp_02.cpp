// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/989596/dohatsu/C++
#include<iostream>
using namespace std;
int n,m=0,a[40],b[40],c[41];
void solve(int l,int r){
  if(l>r)return;
  int x=a[m++];
  solve(l,c[x]-1);
  solve(c[x]+1,r);
  cout<<x<<(x==a[0]?"\n":" ");
}
int main(){
  cin>>n;
  for(int i=0;i<n;i++)cin>>a[i];
  for(int i=0;i<n;i++)cin>>b[i],c[b[i]]=i;
  solve(0,n-1);
  return 0;
}
