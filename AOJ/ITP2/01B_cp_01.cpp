// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/2919330/naoto172/C++
#include <iostream>
#include <deque>
typedef long long int ll;
typedef unsigned long long int ull;
#define BIG_NUM 2000000000
#define MOD 1000000007
#define EPS 0.000000001
using namespace std;

int main(){

	deque<int> DEQ;

	int num_query;
	scanf("%d",&num_query);

	int command,A,B;

	for(int loop = 0; loop < num_query; loop++){
		scanf("%d",&command);

		switch(command){
		case 0:

			scanf("%d %d",&A,&B);
			if(A == 0){
				DEQ.push_front(B);
			}else{
				DEQ.push_back(B);
			}
			break;
		case 1:

			scanf("%d",&A);
			printf("%d\n",DEQ[A]);

			break;
		case 2:
			scanf("%d",&A);
			if(A == 0){
				DEQ.pop_front();
			}else{
				DEQ.pop_back();
			}
			break;
		}
	}

	return 0;
}
