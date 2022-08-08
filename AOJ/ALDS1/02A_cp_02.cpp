// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/1963539/c7c7/C++
#include<iostream>
#include<cstdio>
using namespace std;
int main(){
  int a[10000],n,i,j,t,c=0; cin>>n;
  for(i=0;i<n;i++)cin>>a[i];
  for(i=0;i<n;i++){
    for(j=n-1;j>i;j--){
      if(a[j]<a[j-1]){
        t=a[j];
        a[j]=a[j-1];
        a[j-1]=t;
        c++;
      }
    }
  }
  for(i=0;i<n;i++){if(i){cout<<" ";cout<<a[i];}}
  cout<<'\n'<<c<<endl;
  return 0;
}
