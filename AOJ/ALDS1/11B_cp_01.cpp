// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2181472/c7c7/C++
#include <iostream>
#define r(i,a,n) for(int i=a;i<n;i++)
using namespace std;
int a[101][101],start[101],end[101],n,p=0,v[101];
void dfs(int u){
  if(!v[u]){
    v[u]++;
    start[u]=++p;
    r(i,1,n+1)if(a[u][i]){dfs(i);}
    end[u]=++p;
  }
}
int main(){
  int q,qq,qqq;
  cin>>n;
  r(i,0,n){cin>>q>>qq;
    r(i,0,qq){cin>>qqq;
      a[q][qqq]++;
    }
  }
  r(i,1,n+1)if(!v[i])dfs(i);
  r(i,1,n+1)cout<<i<<' '<<start[i]<<' '<<end[i]<<endl;
}
