// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/1845940/s1230149/C++
#include <iostream>
#define INF 1e9
using namespace std;
long long cnt;

void merge(int A[],int L,int M,int R){
  int n1=M-L;
  int n2=R-M;
  int a[500000],b[500000];
  for(int i=0;i<n1;i++)a[i]=A[L+i];
  for(int i=0;i<n2;i++)b[i]=A[M+i];
  a[n1]=INF,b[n2]=INF;
  int i=0,j=0;

  for(int k=L;k<R;k++){
    if(a[i]<=b[j]) A[k]=a[i++];
    else A[k]=b[j++],cnt+=(n1-i);
  }
}

void mergeSort(int A[],int L,int R){
  if(L+1<R){
    int M=(L+R)/2;
    mergeSort(A,L,M);
    mergeSort(A,M,R);
    merge(A,L,M,R);
  }
}

int main(){
  int n, a[500000];
  cin>>n;
  for(int i=0;i<n;i++)cin>>a[i];
  mergeSort(a,0,n);

  cout <<cnt<<endl;
  return 0;
}
