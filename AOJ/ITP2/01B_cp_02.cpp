// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/2902594/ynymxiaolongbao/C++
#include <iostream>
#include <deque>
using namespace std;
int main(){
	int n;cin>>n;
	deque<int> q;
	while(n--){
		int a,x,y;cin>>a;
		if(a==0){
			cin>>x>>y;
			if(x==0)q.push_front(y);
			if(x==1)q.push_back(y);
		}
		if(a==1){
			cin>>x;
			cout<<q[x]<<endl;
		}
		if(a==2){
			cin>>x;
			if(x==0)q.pop_front();
			if(x==1)q.pop_back();
		}
	}
	return 0;
}
