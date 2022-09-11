// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2398073/beet/C++
#include<iostream>
using namespace std;
#define int long long
int h;
void maxHeapify(int *A,int i){
  int l=i*2+1;
  int r=i*2+2;
  int largest;
  if(l<h&&A[l]>A[i]) largest=l;
  else largest=i;
  if(r<h&&A[r]>A[largest]) largest=r;
  if(largest!=i){
    swap(A[i],A[largest]);
    maxHeapify(A,largest);
  }
}
void insert(int *A,int x){
  int i=h++;
  A[i]=x;
  while(i&&A[(i-1)/2]<A[i]){
    swap(A[(i-1)/2],A[i]);
    i=(i-1)/2;
  }
}
int extract(int *A){
  int res=A[0];
  A[0]=A[--h];
  maxHeapify(A,0);
  return res;
}
int A[2222222];
signed main(){
  string s;
  while(cin>>s,s!="end"){
    if(s=="insert"){
      int x;
      cin>>x;
      insert(A,x);
    }
    if(s=="extract") cout<<extract(A)<<endl;
  }
  return 0;
}
