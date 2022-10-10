// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/2080370/naoto172/C++
#include <stdio.h>
#include <vector>
#include <algorithm>
#include <math.h>
#include <queue>

using namespace std;

//I imitated Ant Book version 1: P.84.

int n,q,com,x,y;
int rank[10000],parent[10000];

int find(int x){
	if(x == parent[x])return x;
	else{
		return parent[x] = find(parent[x]);
	}
}

bool isSame(int x,int y){
	return find(x) == find(y);
}

void unite(int x,int y){
	x = find(x);
	y = find(y);

	if(x == y)return;

	if(rank[x] < rank[y]){
		parent[x] = y;
	}else{
		parent[y] = x;
		if(rank[x] == rank[y])rank[x]++;
	}
}

int main(){

	scanf("%d %d",&n,&q);

	for(int i = 0; i < n; i++){
		rank[i] = 0;
		parent[i] = i;
	}

	for(int i = 0; i < q; i++){
		scanf("%d %d %d",&com,&x,&y);

		if(com == 1){
			if(isSame(x,y))printf("1\n");
			else{
				printf("0\n");
			}
		}else{
			if(isSame(x,y))continue;

			unite(x,y);
		}
	}

	return 0;
}
