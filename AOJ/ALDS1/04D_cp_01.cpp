// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/2398024/beet/C++
#include <iostream>
using namespace std;
#define int long long
signed main(){
  int n,k;
  cin>>n>>k;
  int w[n];
  for(int i=0;i<n;i++) cin>>w[i];
  int sum=0;
  for(int i=0;i<n;i++) sum+=w[i];
  int l=0,r=sum;
  while(l+1<r){
    int m=(l+r)/2;
    int t=0,tmp=0;
    bool f=0;
    for(int i=0;i<n;i++){
      f|=w[i]>m;
      if(tmp+w[i]>m){
        tmp=w[i];
        t++;
      }else{tmp+=w[i];}
    }
    if(tmp) t++;
    if(!f&&t<=k) r=m;
    else l=m;
  }
  cout<<r<<endl;
  return 0;
}
