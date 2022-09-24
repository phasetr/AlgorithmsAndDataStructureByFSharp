// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/3755904/kyopro_friends/C
#include <stdio.h>
#include <stdlib.h>

int ans=45;
int p;
int a[16];
int L1dist(){
  int ret=0;
  for(int i=0;i<16;i++)if(a[i]!=15)ret+=abs(i/4-a[i]/4)+abs(i%4-a[i]%4);
  return ret;
}
void swap(int i,int j){int t=a[i];a[i]=a[j];a[j]=t;}

void f(int pre,int movs){
  int d=L1dist();
  if(movs+d>ans)return;
  if(d==0){
    ans=movs;
    return;
  }
  if(pre!=1&&p>3  )swap(p,p-4),p-=4,f(0,movs+1),p+=4,swap(p,p-4);
  if(pre!=0&&p<12 )swap(p,p+4),p+=4,f(1,movs+1),p-=4,swap(p,p+4);
  if(pre!=3&&p%4>0)swap(p,p-1),p-=1,f(2,movs+1),p+=1,swap(p,p-1);
  if(pre!=2&&p%4<3)swap(p,p+1),p+=1,f(3,movs+1),p-=1,swap(p,p+1);
}

int main(){
  for(int i=0;i<16;i++){
    int t;
    scanf("%d",&t);
    if(t)a[i]=t-1;
    else{
      a[i]=15;
      p=i;
    }
  }
  f(-1,0);
  printf("%d\n",ans);
}
