// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/2919276/naoto172/C++
#include<vector>
#include<iostream>
typedef long long int ll;
typedef unsigned long long int ull;
#define BIG_NUM 2000000000
#define MOD 1000000007
#define EPS 0.000000001
using namespace std;

int main(){
  vector<int> V;

  int num_query;
  scanf("%d",&num_query);

  int command,tmp;

  for(int loop = 0; loop < num_query; loop++){
    scanf("%d",&command);

    switch(command){
    case 0:
      scanf("%d",&tmp);
      V.push_back(tmp);
      break;
    case 1:
      scanf("%d",&tmp);
      printf("%d\n",V[tmp]);
      break;
    case 2:
      V.pop_back();
      break;
    }
  }

  return 0;
}
