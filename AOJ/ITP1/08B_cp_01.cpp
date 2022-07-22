// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/1984792/naoto172/C++
#include <stdio.h>

int main(){
  int sum = 0;
  char ch;

  while(true){
    while((ch = getchar()) != '\n'){
      sum += ch - '0';
    }
    if(sum == 0) { break; }
    else{
      printf("%d\n",sum);
      sum = 0;
    }
  }
}
