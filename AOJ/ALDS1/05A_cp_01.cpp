// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/1980149/naoto172/C++
#include <stdio.h>
#define SIZE 2001

char resultTable[SIZE];
int n,q,elems[20];

void calc(int sum,int index){
  if(index == n){
    if(sum >= 1 && sum <= 2000){
      resultTable[sum] = 'y';
    }
  }else{
    calc(sum+elems[index],index+1);
    calc(sum,index+1);
  }
}

int main(){
  for(int i = 0;i < SIZE; i++) resultTable[i] = 'n';

  scanf("%d",&n);
  for(int i = 0; i < n; i++) scanf("%d",&elems[i]);
  calc(0,0);

  scanf("%d",&q);

  int tmp;
  for(int i = 0; i < q; i++){
    scanf("%d",&tmp);
    if(resultTable[tmp] == 'y'){
      printf("yes\n");
    }else{
      printf("no\n");
    }
  }
}
