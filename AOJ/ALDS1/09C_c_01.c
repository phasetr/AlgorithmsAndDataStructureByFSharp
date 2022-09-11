// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/6196656/vjudge2/C
#include<stdio.h>
#include<string.h>

int H,a[2000005];

void max(int i){
  int l,r,x,temp;
  l = 2*i;
  r = i*2+1;
  if(l>H && r>H){
    return;
  }

  if(l<=H && a[l]>a[i]){
    x = l;
  }else{
    x = i;
  }

  if(r<=H && a[r]>a[x]){
    x = r;
  }

  if(x != i){
    temp = a[i];
    a[i] = a[x];
    a[x] = temp;
    max(x);
  }
}

int extract(){
  int x;
  if(H<1){
    return -1;
  }
  x = a[1];
  a[1] = a[H--];
  max(1);
  return x;
}

void increase(int i, int k){
  if(k<a[i]){
    return;
  }
  a[i] = k;
  while(i>1 && a[i/2]<a[i]){
    int temp = a[i];
    a[i] = a[i/2];
    a[i/2] = temp;
    i = i/2;
  }
}

void insert(int k){
  H++;
  a[H] = -1;
  increase(H,k);
}

int main(){
  int k;
  char cmd[15];
  while(1){
    scanf("%s",cmd);
    getchar();
    if(strcmp(cmd, "insert") == 0){
      scanf("%d",&k);
      insert(k);
    }
    if(strcmp(cmd, "extract") == 0){
      printf("%d\n",extract());
    }
    if(strcmp(cmd, "end") == 0){
      break;
    }
  }
  return 0;
}
