// https://atcoder.jp/contests/abc129/submissions/5843992
#include<stdio.h>
  int h,w,i,j,k,a,m=0,d[4][2010][2010]={};
int main(){
  char s[2010][2010];
  scanf("%d %d",&h,&w);
  for(i=0;i<h;i++)scanf("%s",s[i+1]+1);
  for(i=1;i<=h;i++){
    for(j=1;j<=w;j++){
      if(s[i][j]=='#')continue;
      d[0][i][j]=d[0][i-1][j]+1;
      d[1][i][j]=d[1][i][j-1]+1;
    }
  }
  for(i=h;i;i--){
    for(j=w;j;j--){
      if(s[i][j]=='#')continue;
      d[2][i][j]=d[2][i+1][j]+1;
      d[3][i][j]=d[3][i][j+1]+1;
    }
  }
  for(i=1;i<=h;i++){
    for(j=1;j<=w;j++){
      for(k=a=0;k<4;k++)a+=d[k][i][j];
      if(m<a)m=a;
    }
  }
  printf("%d\n",m-3);
  return 0;
}
