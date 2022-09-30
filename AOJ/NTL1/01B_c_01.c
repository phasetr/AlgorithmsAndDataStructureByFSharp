// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/3759153/kyopro_friends/C
#include <stdio.h>

int main(){
	int a,n;
	scanf("%d%d",&a,&n);
	long s=1,c=a,MOD=1000000007;
	while(n){
		if(n%2)s=s*c%MOD;
		c=c*c%MOD;
		n/=2;
	}
	printf("%ld\n",s);
}
