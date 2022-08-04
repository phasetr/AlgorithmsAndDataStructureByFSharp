// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/916961/dohatsu/C++
#include<iostream>
using namespace std;
int n,key,A[100],j;

void print_table(){
  for(int i=0;i<n;i++){
    if(i){cout<<' ';}
    cout<<A[i];
  }
  cout<<endl;
}

int main(){
  cin>>n;
  for(int i=0;i<n;i++){cin>>A[i];}
  print_table();
  for(int i=1;i<n;i++){
    key=A[i];
    j=i-1;
    while(j>=0&&A[j]>key){
      A[j+1]=A[j];
      j--;
    }
    A[j+1]=key;
    print_table();
  }
  return 0;
}
