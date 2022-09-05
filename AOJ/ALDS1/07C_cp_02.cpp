// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/1858240/s1230146/C++
#include <iostream>
#define N 25
using namespace std;
int n,a[N],l[N],r[N];
bool used[N];

void dfs(int x,int z){
  if(z==0)cout<<' '<<x;
  if(l[x]!=-1)dfs(l[x],z);
  if(z==1)cout<<' '<<x;
  if(r[x]!=-1)dfs(r[x],z);
  if(z==2)cout<<' '<<x;
}

int main(){
  cin>>n;
  for(int i=0;i<n;i++){
    cin>>a[i];
    cin>>l[a[i]]>>r[a[i]];
    if(l[a[i]]!=-1)used[l[a[i]]]=true;
    if(r[a[i]]!=-1)used[r[a[i]]]=true;
  }
  for(int i=0;i<n;i++)
    if(!used[i])cout<<"Preorder"<<endl,dfs(i,0),cout<<endl;
  for(int i=0;i<n;i++)
    if(!used[i])cout<<"Inorder"<<endl,dfs(i,1),cout<<endl;
  for(int i=0;i<n;i++)
    if(!used[i])cout<<"Postorder"<<endl,dfs(i,2),cout<<endl;
  return 0;
}
