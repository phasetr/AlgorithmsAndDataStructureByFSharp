// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2398050/beet/C++
#include<iostream>
using namespace std;
#define int long long
int pre[50],in[50],post[50];
int n,pos,idx;
void dfs(int l,int r){
  if(l>=r) return;
  int root=pre[pos++];
  int m=-1;
  for(int i=l;i<r;i++)
    if(in[i]==root) m=i;
  dfs(l,m);
  dfs(m+1,r);
  post[idx++]=root;
}
signed main(){
  cin>>n;
  for(int i=0;i<n;i++) cin>>pre[i];
  for(int i=0;i<n;i++) cin>>in[i];
  pos=idx=0;
  dfs(0,n);
  for(int i=0;i<n;i++)
    cout<<post[i]<<" \n"[i==n-1];
  return 0;
}
