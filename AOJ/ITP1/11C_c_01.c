// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/3742665/kyopro_friends/C
#include<stdio.h>

int pos[][3]={
  {1,2,3},{1,3,5},{1,4,2},{1,5,4},
  {2,1,4},{2,3,1},{2,4,6},{2,6,3},
  {3,1,2},{3,2,6},{3,5,1},{3,6,5},
  {4,1,5},{4,2,1},{4,5,6},{4,6,2},
  {5,1,3},{5,3,6},{5,4,1},{5,6,4},
  {6,2,4},{6,3,2},{6,4,5},{6,5,3},
};

int d1[7],d2[7];
int main(){
  for(int i=1;i<=6;i++){scanf("%d",d1+i);}
  for(int i=1;i<=6;i++){scanf("%d",d2+i);}
  for(int i=0;i<24;i++){
    int flag=1;
    for(int j=0;j<3;j++){flag&=d1[j+1]==d2[pos[i][j]];}
    for(int j=3;j<6;j++){flag&=d1[j+1]==d2[7-pos[i][5-j]];}
    if(flag){
      puts("Yes");
      return 0;
    }
  }
  puts("No");
}
