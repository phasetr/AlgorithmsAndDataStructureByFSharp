// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/920644/dohatsu/C++
#include<iostream>
#include<algorithm>
using namespace std;
int main(){
  int n,A[100],ans=0;
  cin>>n;
  for(int i=0;i<n;i++)cin>>A[i];
  for(int i=0;i<n-1;i++){
    for(int j=n-1;j>i;j--){
      if(A[j]<A[j-1]){
        swap(A[j],A[j-1]);
        ans++;
      }
    }
  }
  for(int i=0;i<n;i++){
    if(i){cout<<' ';}
    cout<<A[i];
  }
  cout<<endl<<ans<<endl;
  return 0;
}
