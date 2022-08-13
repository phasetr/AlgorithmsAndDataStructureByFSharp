// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/5892464/vjudge2/C
#include<stdio.h>
#include<string.h>
typedef struct node{
  int time;
  char name[10];
}Node;
Node quee[300000];
int head=0,tail=0;

int main(){
  int m,n,t,sum=0;
  char na[10];
  scanf("%d",&m);
  scanf("%d",&n);
  for(int i=0;i<m;i++){
    scanf("%s",quee[i].name);
    scanf("%d",&quee[i].time);
    tail++;
  }
  while(head!=tail){
    if(quee[head].time<=n){
      sum+=quee[head].time;
      printf("%s %d\n",quee[head].name,sum);
      head++;
    } else {
      sum+=n;
      quee[head].time-=n;
      quee[tail]=quee[head];
      tail++;
      head++;
    }
  }
  return 0;
}
