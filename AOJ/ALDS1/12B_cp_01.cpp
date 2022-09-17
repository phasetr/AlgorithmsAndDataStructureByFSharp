// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/598074/leafmoon/C++
#include <map>
#include <vector>
#include <cstdio>
using namespace std;
int main(){
  int n=0,N,i,j,k,c;
  scanf("%d",&N);
  vector<map<int,int> >dist(N);
  vector<bool>used(N);
  vector<int>cost(N);
  for(;n<N;n++){
    cost[n]=999999;
    for(scanf("%d%d",&i,&k);k--;dist[i][j]=c)scanf("%d%d",&j,&c);
  }
  for(cost[0]=0;;){ //dijkstra
    int m=999999;
    for(i=0;i<N;i++)if(!used[i]&&m>cost[i])m=cost[i];
    if(m==999999)break;
    for(j=0;j<N;j++)if(m==cost[j]){
      map<int,int>::iterator it=dist[j].begin();
      for(used[j]=1;it!=dist[j].end();it++)if(cost[it->first]>it->second+cost[j])cost[it->first]=it->second+cost[j];
    }
  }
  for(i=0;i<n;i++)printf("%d %d\n",i,cost[i]);
}
