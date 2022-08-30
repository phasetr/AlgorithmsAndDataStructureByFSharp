// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/2398011/beet/C++
#include <iostream>
#include <map>
using namespace std;
#define int long long
typedef pair<int,char> P;
int partition(P* A,int p,int r){
  int x=A[r].first;
  int i=p-1;
  for(int j=p;j<r;j++){
    if(A[j].first<=x){
      i++;
      swap(A[i],A[j]);
    }
  }
  swap(A[i+1],A[r]);
  return i+1;
}
void quicksort(P* A,int p,int r){
  if(p<r){
    int q=partition(A,p,r);
    quicksort(A,p,q-1);
    quicksort(A,q+1,r);
  }
}
signed main(){
  int n;
  cin>>n;
  P A[n];
  for(int i=0;i<n;i++) cin>>A[i].second>>A[i].first;
  map<int,string> m1,m2;
  for(int i=0;i<n;i++) m1[A[i].first]+=A[i].second;
  quicksort(A,0,n-1);
  for(int i=0;i<n;i++) m2[A[i].first]+=A[i].second;
  bool flag=1;
  for(int i=0;i<n;i++) flag&=m1[A[i].first]==m2[A[i].first];
  if(flag) cout<<"Stable"<<endl;
  else cout<<"Not stable"<<endl;
  for(int i=0;i<n;i++){
    cout<<A[i].second<<" "<<A[i].first<<endl;
  }
  return 0;
}
