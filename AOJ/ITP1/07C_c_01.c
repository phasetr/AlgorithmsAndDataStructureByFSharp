// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/1049136/TKT29/C
#include <stdio.h>

int main(void){
  int r,c,i,j;
  static int s[101][101];

  scanf("%d%d",&r,&c);

  for(i=0;i<=r;i++){
    for(j=0;j<c;j++){
      scanf("%d", &s[i][j]);
      printf("%d ", s[i][j]);
      s[i][c] += s[i][j];
      s[r][j] += s[i][j];
    }
    printf("%d\n",s[i][c]);
  }

  return 0;
}
