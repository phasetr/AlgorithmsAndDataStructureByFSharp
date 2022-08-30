// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/970351/dohatsu/C++
#include<iostream>
#include<algorithm>
using namespace std;

struct Data{
  int num,id;
  char ch;
};

int Partition(Data A[],int p,int r){
  Data x = A[r];
  int i=p-1;
  for(int j=p;j<r;j++){
    if(A[j].num<=x.num){
      i++;
      swap(A[i],A[j]);
    }
  }
  swap(A[i+1],A[r]);
  return i+1;
}

void Quicksort(Data A[],int p,int r){
  if(p<r){
    int q = Partition(A,p,r);
    Quicksort(A,p,q-1);
    Quicksort(A,q+1,r);
  }
}

void check(Data A[],int n){
  for(int i=1;i<n;i++){
    if(A[i-1].num<A[i].num)continue;
    if(A[i-1].id<A[i].id)continue;
    cout<<"Not stable"<<endl;
    return;
  }
  cout<<"Stable"<<endl;
}

int main(){
  int n;
  Data A[100000];
  cin>>n;
  for(int i=0;i<n;i++){
    cin>>A[i].ch>>A[i].num;
    A[i].id=i;
  }

  Quicksort(A,0,n-1);
  check(A,n);
  for(int i=0;i<n;i++){
    cout<<A[i].ch<<' '<<A[i].num<<endl;
  }

  return 0;
}
