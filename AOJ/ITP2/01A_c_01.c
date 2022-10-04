// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/2962672/bal4u/C
// AOJ ITP2_1_A: Vector
// 2018.6.24 bal4u

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char Q[200005][13];
int end;
char a[30];

int main()
{
  int q;

  fgets(a, 30, stdin), q = atoi(a);
  while (q--) {
    fgets(a, 30, stdin);
    if (a[0] == '0') strcpy(Q[end++], a+2); // pushBack
    else if (a[0] == '1') printf(Q[atoi(a+2)]); // randomAccess
    else --end; // popBack
  }
  return 0;
}
