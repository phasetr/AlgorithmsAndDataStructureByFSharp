// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/1915737/s1230146/C++
#include<iostream>
#define N 105
using namespace std;
int n,u,k,v,e[N][N],cnt;
int ans1[N],ans2[N];
bool used[N];

void dfs(int x){
  if(used[x])return;
  used[x]=true;
  ans1[x]=cnt++;
  for(int i=0;i<n;i++)
    if(e[x][i])dfs(i);
  ans2[x]=cnt++;
}

int main(){
  cin>>n;
  for(int i=0;i<n;i++){
    cin>>u>>k;
    for(int j=0;j<k;j++)
      cin>>v,e[u-1][v-1]=1;
  }
  cnt=1;
  for(int i=0;i<n;i++){
    if(!used[i])dfs(i);
  }
  for(int i=0;i<n;i++){
    cout<<i+1<<' '<<ans1[i]<<' '<<ans2[i]<<endl;
  }
  return 0;
}
