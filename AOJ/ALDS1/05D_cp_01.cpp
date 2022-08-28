// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/1538230/issysan/C++
#include <cstdio>
#include <algorithm>
using namespace std;
long long cnt;
int n;

void merge(int A[],int left,int mid,int right){
  int L[100005],R[100005];
  int n1=(mid-left);
  int n2=(right-mid);
  for(int i=0;i<n1;i++){
    L[i]=A[left+i];
  }
  for(int i=0;i<n2;i++){
    R[i]=A[mid+i];
  }
  L[n1]=2e9;
  R[n2]=2e9;
  int i,j;
  i=j=0;
  for(int k=left;k<right;k++){
    if(L[i]<=R[j]){
      A[k]=L[i++];
    }else{
      A[k]=R[j++];
      cnt+=(n1-i);
    }
  }
}

void mergeSort(int A[],int left,int right){
  if(left+1<right){
    int mid=(left+right)/2;
    mergeSort(A,left,mid);
    mergeSort(A,mid,right);
    merge(A,left,mid,right);
  }
}

int main(void){
  int a[200005];
  scanf("%d",&n);
  for(int i=0;i<n;i++){
    scanf("%d",&a[i]);
  }
  mergeSort(a,0,n);
  printf("%lld\n",cnt);
  return 0;
}

