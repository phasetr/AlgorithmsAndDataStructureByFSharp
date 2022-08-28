// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/5179586/vjudge2/C
#include<stdio.h>
int a1[500000],b1;
long long b2;
void sort2(int a,int b){
  long long c,d,e,f,g[250001],h[250001],i=0,j=0,k;
  c=(a+b)/2;
  d=c-a;
  e=b-c;
  k=d;
  for(f=0;f<d;f++) {g[f]=a1[a+f];}
  for(f=0;f<e;f++) {h[f]=a1[c+f];}
  g[d]=h[e]=2000000000;
  for(f=a;f<b;f++){
    if(g[i]>h[j]){
      a1[f]=h[j++];
      b2+=k;
    }else{
      a1[f]=g[i++];
      k--;
    }
  }
}
void sort1(int a,int b){
  if(a+1>=b){return;}
  int c=(a+b)/2;
  sort1(a,c);
  sort1(c,b);
  sort2(a,b);
}
int main(){
  int a,b,c,d;
  scanf("%d",&b1);
  for(a=0;a<b1;a++) {scanf("%d",&a1[a]);}
  sort1(0,b1);
  printf("%lld\n",b2);
}
