// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/6258046/vjudge2/C
#include<stdio.h>
#include<string.h>
char s[10][10];
int book[10],t,n,m,a[20],d[20],c[10];
void dfs(int x){
  if(c[x]==1){dfs(x+1);}
  if(x==8) {
    for(int i=0;i<8;i++){printf("%s\n",s[i]);}
    return;
  }
  for(int i=0;i<8;i++){
    if(book[i]==0 && a[x+i]==0 && d[x-i+8]==0){
      book[i]=1;
      a[x+i]=1;
      d[x-i+8]=1;
      s[x][i]='Q';
      dfs(x+1);
      book[i]=0;
      a[x+i]=0;
      d[x-i+8]=0;
      s[x][i]='.';
    }
  }
}
int main(){
  scanf("%d",&t);
  for(int i=0;i<8;i++){
    for(int j=0;j<8;j++){s[i][j]='.';}
  }
  for(int i=0;i<t;i++){
    scanf("%d%d",&n,&m);
    s[n][m]='Q';
    book[m]=1;
    a[n+m]=1;
    d[n-m+8]=1;
    c[n]=1;
  }
  dfs(0);
  return 0;
}
