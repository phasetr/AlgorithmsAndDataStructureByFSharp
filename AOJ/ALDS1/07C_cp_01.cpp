// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/1604389/E869120/C++
#include<iostream>
#include<cstring>
using namespace std;

int x[1000][5];//0=left,1=right,2=parent,3=sibling;

void S1(int u){
  if(u==-1){
    return;
  }
  cout<<' '<<u;
  S1(x[u][0]);
  S1(x[u][1]);
}

void S2(int u){
  if(u==-1){
    return;
  }
  S2(x[u][0]);
  cout<<' '<<u;
  S2(x[u][1]);
}

void S3(int u){
  if(u==-1){
    return;
  }
  S3(x[u][0]);
  S3(x[u][1]);
  cout<<' '<<u;
}

int main(){
  memset(x,-1,sizeof(x));
  int n,a,c;
  cin>>n;
  for(int i=0;i<n;i++){
    cin>>a;
    cin>>x[a][0]>>x[a][1];
    x[x[a][0]][2]=a;
    x[x[a][1]][2]=a;
    x[x[a][0]][3]=x[a][1];
    x[x[a][1]][3]=x[a][0];
  }
  cout<<"Preorder"<<endl;
  for(int i=0;i<n;i++){
    if(x[i][2]==-1){
      c=i;
      break;
    }
  }
  S1(c);cout<<endl;
  cout<<"Inorder"<<endl;
  S2(c);cout<<endl;
  cout<<"Postorder"<<endl;
  S3(c);cout<<endl;
  return 0;
}
