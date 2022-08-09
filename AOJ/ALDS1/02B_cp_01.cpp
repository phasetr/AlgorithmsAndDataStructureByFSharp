// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/2398016/beet/C++
#include <iostream>
using namespace std;
#define int long long
signed main(){
  int n;
  cin>>n;
  int A[n];
  for(int i=0;i<n;i++) {cin>>A[i];}
  int ans=0;
  for(int i=0;i<n;i++){
    int minj=i;
    for(int j=i;j<n;j++){
      if(A[j]<A[minj]){
        minj=j;
      }
    }
    if(i!=minj){
      swap(A[i],A[minj]);
      ans++;
    }
  }
  for(int i=0;i<n;i++) {cout<<A[i]<<" \n"[i==n-1];}
  cout<<ans<<endl;
  return 0;
}
