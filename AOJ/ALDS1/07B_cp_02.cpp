// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/1443641/dohatsu/C++
#include<stdio.h>

int max(int a,int b){return (a<b?b:a);};
typedef struct {
  int p,s,deg,dep,h,left,right;
} Node;

Node t[100000];
int n;

void setdepth(int x){
  if(t[x].p==-1){
    t[x].dep=0;
    return;
  }
  if(t[x].dep==-1){
    setdepth(t[x].p);
    t[x].dep=t[t[x].p].dep+1;
  }
}

void setheight(int x){

  int l=t[x].left;
  int r=t[x].right;
  if(t[x].deg==0){
    t[x].h=0;
    return;
  }
  if(t[x].h==-1){
    if(l!=-1){
      setheight(l);
      t[x].h=max(t[x].h,t[l].h+1);
    }
    if(r!=-1){
      setheight(r);
      t[x].h=max(t[x].h,t[r].h+1);
    }
  }
}

void init(){
  int i;
  for(i=0;i<100000;i++){
    t[i].p=t[i].s=t[i].deg=t[i].dep=t[i].h=t[i].left=t[i].right=-1;
  }
}

int main(){
  init();
  int i,id,a,b;

  scanf("%d",&n);
  for(i=0;i<n;i++){
    scanf("%d %d %d",&id,&a,&b);
    if(a!=-1){
      t[id].left=a;
      t[a].p=id;
    }
    if(b!=-1){
      t[id].right=b;
      t[b].p=id;
    }
    if(a!=-1&&b!=-1){
      t[a].s=b;
      t[b].s=a;
    }
    t[id].deg=(a!=-1)+(b!=-1);

  }

  for(i=0;i<n;i++){
    printf("node %d: parent = %d, sibling = %d, degree = %d, ",i,t[i].p,t[i].s,t[i].deg);
    setdepth(i);
    setheight(i);
    printf("depth = %d, height = %d, ",t[i].dep,t[i].h);

    if(t[i].p==-1)printf("root\n");
    else if(t[i].deg!=0)printf("internal node\n");
    else printf("leaf\n");

  }
  return 0;
}
