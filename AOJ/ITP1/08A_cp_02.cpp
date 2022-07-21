// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/1988972/naoto172/C++
#include <stdio.h>
int main(){
  char ch;
  while((ch = getchar()) != EOF){
    if(ch >= 97 && ch <= 122) { printf("%c",ch-32); }
    else if(ch >= 65 && ch <= 90) { printf("%c",ch+32); }
    else { printf("%c",ch); }
  }
}
