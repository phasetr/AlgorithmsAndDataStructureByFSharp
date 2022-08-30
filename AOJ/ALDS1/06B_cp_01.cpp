// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/2397963/beet/C++
//#include <bits/stdc++.h>
#include <iostream>
#include <algorithm>
using namespace std;
#define int long long
int partition(int* A,int p,int r){
  int x=A[r];
  int i=p-1;
  for(int j=p;j<r;j++){
    if(A[j]<=x){
      i++;
      swap(A[i],A[j]);
    }
  }
  swap(A[i+1],A[r]);
  return i+1;
}
signed main(){
  int n;
  cin>>n;
  int A[n];
  for(int i=0;i<n;i++) { cin>>A[i]; }
  int k=partition(A,0,n-1);
  for(int i=0;i<n;i++){
    if(i) cout<<" ";
    if(i==k) cout<<"[";
    cout<<A[i];
    if(i==k) cout<<"]";
  }
  cout<<endl;
  return 0;
}
