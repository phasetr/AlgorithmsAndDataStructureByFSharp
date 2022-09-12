// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/694076/leafmoon/C++
// http://algorithms.blog55.fc2.com/blog-entry-66.html
#include <stdio.h>
#include <string.h>

#define M 100
int R[M+1],C[M][M],B[M][M];
void D(int i,int j){
  if(i==j)printf("M%d",i);
  else printf("("),D(i,B[i][j]-1),D(B[i][j],j),printf(")");
}

int main(){
  int N,i=0,j,k,c;
  scanf("%d",&N);
  for(;i<N;i++)scanf("%d%d",R+i,&c);
  R[i]=c;
  memset(C,99,sizeof(C));
  for(i=0;i<N;i++) {C[i][i]=0;}
  for(j=1;j<N;j++){
    for(i=0;i<N-j;i++){
      for(k=i;k<i+j;k++){
        if((c=C[i][k]+C[k+1][i+j]+R[i]*R[k+1]*R[i+j+1])<C[i][i+j]) {C[i][i+j]=c,B[i][i+j]=k;}
      }
    }
  }
  printf("%d\n",C[0][N-1]);
  //order(0,N);
  //puts("");
}
