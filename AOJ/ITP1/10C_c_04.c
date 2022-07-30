// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/921967/Iceman/C
#include<stdio.h>
#include<math.h>
int main()
{
  int n,s[1005],i;
  double a,x;
  for(;scanf("%d",&n),n;) {
    for(i=a=0;i<n;a+=s[i++]) {scanf("%d",&s[i]);}
    a/=n;
    for(i=x=0;i<n;i++) {x+=(s[i]-a)*(s[i]-a);}
    printf("%.8f\n",sqrt((double)x/n));
  }
  return 0;
}
