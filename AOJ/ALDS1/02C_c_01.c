// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/3743068/kyopro_friends/C
#include<stdio.h>

int a[110];
int b[110];

int main(){
  int n;
  scanf("%d",&n);
  for(int i=0;i<n;i++){
    char c;
    int d;
    scanf(" %c%d",&c,&d);
    b[i]=a[i]=c*10+d;
  }

  for(int i=0;i<n;i++){
    int idx=i;
    for(int j=i+1;j<n;j++){if(a[j]%10<a[idx]%10){idx=j;}}
    int t=a[i];
    a[i]=a[idx];
    a[idx]=t;
  }

  for(int i=n-1;i>=0;i--){for(int j=0;j<i;j++){if(b[j]%10>b[j+1]%10){
    int t=b[j];
    b[j]=b[j+1];
    b[j+1]=t;
  }}}
  for(int i=0;i<n;i++){printf("%c%d%c",b[i]/10,b[i]%10,i==n-1?10:32);}
  puts("Stable");
  int flag=1;
  for(int i=0;i<n;i++){printf("%c%d%c",a[i]/10,a[i]%10,i==n-1?10:32),flag&=a[i]==b[i];}
  puts(flag?"Stable":"Not stable");
}
