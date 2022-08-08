// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/954339/Iceman/C
#include<stdio.h>
int N,A[100],c=0,i,j;
int main(){
  for(i=0,scanf("%d",&N);i<N;scanf("%d",&A[i++]));
  for(i=0;i<N-1;i++)
    for(j=N-1;j>i;j--){
      if(A[j]<A[j-1]){
        c++;
        A[j]^=A[j-1]^=A[j]^=A[j-1];
      }
    }
  for(i=0;i<N;i++){printf("%d%s",A[i],i==N-1?"\n":" ");}
  printf("%d\n",c);
  return 0;
}
