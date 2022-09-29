// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/3756185/kyopro_friends/C
#include <stdio.h>
#define MOD 1000000009
#define e 32769

char s[1010][1010];
char t[1010][1010];
int tatehash[1010][1010];

int main(){
  int n,m,a,b;
  scanf("%d%d",&n,&m);
  for(int i=0;i<n;i++)scanf(" %s",s[i]);
  scanf("%d%d",&a,&b);
  for(int i=0;i<a;i++)scanf(" %s",t[i]);

  long po=1;
  for(int j=0;j<b;j++)po=po*e%MOD;
  long popo=1;
  for(int i=0;i<a;i++)popo=popo*po%MOD;
  for(int j=0;j<m;j++){
    long hash=0;
    for(int i=0;i<a;i++)hash=(hash*po+s[i][j])%MOD;
    for(int i=a;i<=n;i++){
      tatehash[i-a][j]=hash;
      hash=((hash*po+s[i][j]-s[i-a][j]*popo)%MOD+MOD)%MOD;
    }
  }
  long thash=0;
  for(int i=0;i<a;i++)for(int j=0;j<b;j++)thash=(thash*e+t[i][j])%MOD;

  for(int i=0;i<=n-a;i++){
    long hash=0;
    for(int j=0;j<b;j++)hash=(hash*e+tatehash[i][j])%MOD;
    for(int j=b;j<=m;j++){
      if(thash==hash)printf("%d %d\n",i,j-b);
      hash=((hash*e+tatehash[i][j]-tatehash[i][j-b]*po)%MOD+MOD)%MOD;
    }
  }
}
