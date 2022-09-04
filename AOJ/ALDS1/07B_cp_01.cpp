// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/1604594/E869120/C++
#include<iostream>
#include<cstring>
#include<string>
#include<algorithm>
using namespace std;

int x[1000][10];
int n,a,c,d,e;
string T[3]={"root","internal node","leaf"};

void depth(int s,int r){
  if(s==-1){
    return;
  }
  x[s][4]=r;
  depth(x[s][0],r+1);
  depth(x[s][1],r+1);
}

int height(int s){
  int h1=0,h2=0;
  if(x[s][0]!=-1){
    h1=height(x[s][0])+1;
  }
  if(x[s][1]!=-1){
    h2=height(x[s][1])+1;
  }
  return x[s][5]=max(h1,h2);
}

int main(){
  memset(x,-1,sizeof(x));
  cin>>n;
  for(int i=0;i<n;i++){
    x[i][5]=0;
    x[i][6]=0;
    cin>>a>>d>>e;
    x[a][0]=d;
    x[a][1]=e;
    x[d][2]=a;
    x[e][2]=a;
    x[d][3]=e;
    x[e][3]=d;
  }
  for(int i=0;i<n;i++){
    if(x[i][2]==-1){
      c=i;
      break;
    }
  }
  depth(c,0);
  height(c);
  for(int i=0;i<n;i++){
    if(x[i][0]>=0){
      x[i][6]++;
    }
    if(x[i][1]>=0){
      x[i][6]++;
    }
  }
  for(int i=0;i<n;i++){
    if(i==c){
      x[i][7]=0;
    }
    else if(x[i][6]>=1){
      x[i][7]=1;
    }
    else{
      x[i][7]=2;
    }
  }
  for(int i=0;i<n;i++){
    cout<<"node "<<i<<": parent = "<<x[i][2]<<", sibling = "<<x[i][3]<<", degree = "<<x[i][6]<<", depth = "<<x[i][4]<<", height = "<<x[i][5]<<", "<<T[x[i][7]]<<endl;
  }
  return 0;
}
