// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/3750020/kyopro_friends/C
#include <stdio.h>
#include <string.h>
#define max(p,q)((p)>(q)?(p):(q))
#define min(p,q)((p)<(q)?(p):(q))
int a[20010];
int l[20010];
int r[20010];
int d[20010];

char s[20010];
int ans[20010],cnt,sum;

int main(){
  scanf("%s",s);
  int n=strlen(s);
  for(int i=0;i<n;i++)a[i+1]=a[i]+(s[i]=='\\'?-1:s[i]=='/');
  l[0]=a[0];
  for(int i=0;i<n;i++)l[i+1]=max(l[i],a[i+1]);
  r[n]=a[n];
  for(int i=n;i>0;i--)r[i-1]=max(r[i],a[i-1]);
  for(int i=0;i<=n;i++)d[i]=min(l[i],r[i])-a[i];
  int temp=0;
  for(int i=0;i<=n;i++){
    if(d[i]==0){
      if(temp!=0){
        ans[cnt++]=temp;
        sum+=temp;
        temp=0;
      }
    }else temp+=d[i];
  }
  printf("%d\n%d%c",sum,cnt,cnt?32:10);
  for(int i=0;i<cnt;i++)printf("%d%c",ans[i],i==cnt-1?10:32);
}
