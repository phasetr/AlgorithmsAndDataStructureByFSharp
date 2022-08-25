// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/3750215/kyopro_friends/C
#include <stdio.h>

int n;
int w[100010];

int f(int m){
  int ans=0,temp=0;
  for(int i=0;i<n;i++){
    if(w[i]>m)return 1e9;
    if(temp+w[i]<=m)temp+=w[i];
    else{
      ans++;
      temp=w[i];
    }
  }
  return ans+1;
}

int main(){
  int k;
  scanf("%d%d",&n,&k);
  for(int i=0;i<n;i++)scanf("%d",w+i);
  int l=0,r=1e9;//lはng,rはok
  while(r-l>1){
    int m=(l+r)/2;
    if(f(m)<=k)r=m;
    else l=m;
  }
  printf("%d\n",r);
}
