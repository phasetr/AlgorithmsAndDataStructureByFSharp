// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_A/review/3759297/kyopro_friends/C
#include <stdio.h>
#include <string.h>

char s[100010];
char t[100010];

int ans[100010];
int main(){
  scanf("%s %s",s,t);
  int sm=(s[0]=='-'),tm=(t[0]=='-');
  int sn=strlen(s+sm),tn=strlen(t+tm);
  for(int i=0;i<sn;i++){
    if(sm)ans[i]-=s[sn+sm-1-i]-'0';
    else ans[i]+=s[sn-1-i]-'0';
  }
  for(int i=0;i<tn;i++){
    if(tm)ans[i]-=t[tn+tm-1-i]-'0';
    else ans[i]+=t[tn-1-i]-'0';
  }
  for(int i=0;i<100005;i++){
    while(ans[i]<0)ans[i]+=10,ans[i+1]--;
    while(ans[i]>9)ans[i]-=10,ans[i+1]++;
  }
  if(ans[100005]<0){
    printf("-");
    for(int i=0;i<100005;i++)ans[i]=9-ans[i];
    ans[0]++;
    int crr=0;
    while(ans[crr]==10)ans[crr]=0,ans[++crr]++;
  }
  int digit=0;
  for(int i=0;i<100005;i++)if(ans[i])digit=i;
  for(int i=digit;i>=0;i--)printf("%d",ans[i]);
  puts("");
}
