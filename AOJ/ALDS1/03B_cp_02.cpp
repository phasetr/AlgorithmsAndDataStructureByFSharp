// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/750570/ei1333/C++
#include<iostream>
#include<string>
#include<utility>
#include<queue>
using namespace std;
int main(){
  int n,q,time,cnt_time = 0;
  string name;
  queue<pair<string,int>> que;
  cin >> n >> q;
  for(int i=0;i<n;i++){
    cin >> name >> time;
    que.push(make_pair(name,time));
  }
  while(!que.empty()){
    pair<string,int> top = que.front();
    que.pop();
    if(top.second <= q){
      cnt_time += top.second;
      cout << top.first << " " << cnt_time << endl;
    }else{
      cnt_time += q;
      que.push(make_pair(top.first,top.second-q));
    }
  }
}
