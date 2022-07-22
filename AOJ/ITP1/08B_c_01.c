// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/4742766/vjudge2/C
#include<stdio.h>
int main(void){
  char num[1000];
  int sum, i;

  while(1) {
    sum=0;
    scanf("%s", num);
    if(num[0]=='0') { break; }
    for(i=0; num[i]!='\0'; i++){
      sum+=num[i]-'0';
    }
    printf("%d\n", sum);
  }
  return 0;
}
