// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_B/review/1828203/beet/C++
#include <cstdio>
int main(){
  int n,x;
  scanf("%d%d",&n,&x);
  while(n!=0||x!=0){
    int i,j,k;
    int o=0;
    for(i=1;i<=n;i++){
      for(j=i+1;j<=n;j++){
        for(k=j+1;k<=n;k++){
          if(i+j+k==x){o++;}
        }
      }
    }
    printf("%d\n", o);
    scanf("%d%d",&n,&x);
  }
  return 0;
}
