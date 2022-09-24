// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/1443830/dohatsu/C++
#include<iostream>
#include<cmath>
#include<algorithm>
using namespace std;

int dy[]={-1,0,1,0};
int dx[]={0,1,0,-1};

int t[4][4];
int limit;

int getHeuri(){
  int res=0,a;
  for(int i=0;i<4;i++){
    for(int j=0;j<4;j++){
      if(t[i][j]==0)continue;
      a=t[i][j]-1;
      res+=abs(a/4-i)+abs(a%4-j);
    }
  }
  return res;
}

bool check(int depth,int prev,int py,int px){
  int heuri=getHeuri();
  if(heuri+depth>limit)return false;
  if(heuri==0)return true;
  for(int i=0;i<4;i++){
    if(abs(i-prev)==2)continue;
    int ny=py+dy[i],nx=px+dx[i];
    if(ny<0||nx<0)continue;
    if(ny>=4||nx>=4)continue;
    swap(t[ny][nx],t[py][px]);
    if(check(depth+1,i,ny,nx)) return true;
    swap(t[ny][nx],t[py][px]);
  }
  return false;
}

void solve(int py,int px){
  for(limit=0;;limit++){
    if(check(0,99,py,px)){
      cout<<limit<<endl;
      return;
    }
  }
}

int main(){
  int py,px;
  for(int i=0;i<4;i++){
    for(int j=0;j<4;j++){
      cin>>t[i][j];
      if(t[i][j]==0){
    py=i;
    px=j;
      }
    }
  }
  solve(py,px);
  return 0;
}
