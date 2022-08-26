// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2472140/jakenu0x5e/Python3
#include<stdio.h>
#include<limits.h>
int A[500005],N,c=0,i,tmp[2][250005];
void marge(int l,int m,int r){
  int i,j,c1=m-l,c2=r-m;
  for(i=0;i<c1;i++)tmp[0][i]=A[l+i];
  for(i=0;i<c2;i++)tmp[1][i]=A[m+i];
  tmp[0][c1]=tmp[1][c2]=INT_MAX;
  for(i=j=0;i<c1||j<c2;c++){
    if(tmp[0][i]<tmp[1][j]){
      A[l+i+j]=tmp[0][i];
      i++;
    }else{
      A[l+i+j]=tmp[1][j];
      j++;
    }
  }
}

void margeSort(int l,int r){
  int m;
  if(l+1<r){
    m=(l+r)/2;
    margeSort(l,m);
    margeSort(m,r);
    marge(l,m,r);
  }
}

int main(){
  scanf("%d",&N);
  for(i=0;i<N;i++) {scanf("%d",A+i);}
  margeSort(0,N);
  for(i=0;i<N;i++) {printf("%d%c",A[i],i==N-1?'\n':' ');}
  printf("%d\n",c);
  return 0;
}
