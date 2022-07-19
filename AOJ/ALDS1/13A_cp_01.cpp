// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/1942685/s1220013/C++
#include <iostream>
#define MAX 8
using namespace std;

bool c[MAX],x[MAX*2-1],y[MAX*2-1];
int r[MAX];

void init(){
  for(int i=0;i<MAX;i++){
    r[i]=-1;
    c[i]=false;
  }
  for(int i=0;i<MAX*2-1;i++){
    x[i]=false;
    y[i]=false;
  }
}

void print(){
  for(int i=0;i<MAX;i++){
    for(int j=0;j<MAX;j++){
      if(r[i]==j)cout<<'Q';
      else cout<<'.';
    }
    cout<<endl;
  }
}

void rec(int n){
  if(n==MAX)print();
  else if(r[n]!=-1)rec(n+1);
  else {
    for(int i=0;i<MAX;i++){
      if(!c[i] && !x[MAX-1-n+i] && !y[n+i]){
        r[n]=i;
        c[i]=true;
        x[MAX-1-n+i]=true;
        y[n+i]=true;
        rec(n+1);
        r[n]=-1;
        c[i]=false;
        x[MAX-1-n+i]=false;
        y[n+i]=false;
      }
    }
  }
}

int main(){
  int n,a,b;
  init();
  cin>>n;
  for(int i=0;i<n;i++){
    cin>>a>>b;
    r[a]=b;
    c[b]=true;
    x[MAX-1-a+b]=true;
    y[a+b]=true;
  }
  rec(0);
  return 0;
}
