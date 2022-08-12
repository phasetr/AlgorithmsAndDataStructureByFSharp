// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/3743116/kyopro_friends/C
#include<stdio.h>

int n;
int a[1000010];
int ans[100],len;
int cnt;

int main(){
  scanf("%d",&n);
  for(int i=0;i<n;i++){scanf("%d",a+i);}
  ans[len++]=1;
  while(ans[len-1]*3+1<n){ans[len]=ans[len-1]*3+1,len++;}
  for(int k=len-1;k>=0;k--){
    for(int i=0;i<n;i++){
      int t=a[i];
      int j=i;
      while(j-ans[k]>=0&&a[j-ans[k]]>t){
        a[j]=a[j-ans[k]];
        j-=ans[k];
        cnt++;
      }
      a[j]=t;
    }
  }
  printf("%d\n",len);
  for(int i=len-1;i>=0;i--){printf("%d%c",ans[i],i?32:10);}
  printf("%d\n",cnt);
  for(int i=0;i<n;i++){printf("%d\n",a[i]);}
}
