// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/794749/s1190048/C++
#include<iostream>

#define REP(i,s,n) for(int i=s;i<n;i++)
#define rep(i,n) REP(i,0,n)
#define MAX 10010
using namespace std;

int par[MAX];

int find(int x){
  if(x == par[x])return x;
  return par[x] = find(par[x]);
}

void unit(int x,int y){
  x = find(x), y = find(y);
  if(x != y)par[x] = y;
  find(x),find(y);
}

int main(){
  int n,q,com,x,y;
  cin >> n >> q;
  rep(i,n)par[i] = i;
  rep(i,q){
    cin >> com >> x >> y;
    if(com == 0)unit(x,y);
    else cout << (find(x)==find(y)?1:0) << endl;
  }

  return 0;
}
