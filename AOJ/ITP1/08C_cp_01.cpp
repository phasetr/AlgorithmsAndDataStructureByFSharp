// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/1984735/naoto172/C++
#include <stdio.h>
int main(){
  int countTable[256] = {0};
  char ch;

  while((ch = getchar()) != EOF){
    countTable[ch]++;
  }
  for(int i = 97; i <=122;i++){printf("%c : %d\n",i,countTable[i]+countTable[i-32]);}
}
