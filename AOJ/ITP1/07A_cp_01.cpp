// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_A/review/1988893/naoto172/C++
#include <stdio.h>
using namespace std;
int main(){
  int m,f,r,s;
  char grade;
  while(true){
    scanf("%d %d %d",&m,&f,&r);
    if(m == -1 && f == -1 && r == -1){break;}
    s=m+f;
    if(m == -1 || f == -1){grade = 'F';}
    else if(80<=s){grade = 'A';}
    else if(65<=s){grade = 'B';}
    else if(50<=s){grade = 'C';}
    else if(30<=s){grade = (50<=r)? 'C':'D';}
    else{grade = 'F';}
    printf("%c\n",grade);
  }
}
