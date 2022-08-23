// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/922411/s1190048/C++
#include <deque>
#include <iostream>
#include <utility>
#define REP(i,s,n) for(int i=s;i<n;i++)
#define rep(i,n) REP(i,0,n)
using namespace std;
typedef pair<int,int> ii;
string s;

int main(){
  getline(cin,s);
  deque<ii> ans;
  deque<int> deq;
  rep(i,s.size()){
    if( s[i] == '\\' ) deq.push_back(i);
    else if( s[i] == '/' && !deq.empty() ){
      int sp = deq.back(); deq.pop_back();
      int area = i - sp;
      while( !ans.empty() && sp <= ans.back().first ){
        area += ans.back().second;
        ans.pop_back();
      }
      ans.push_back(ii(sp,area));
    }
  }
  int sum = 0;
  rep(i,ans.size()) sum += ans[i].second;
  cout << sum << endl << (int)ans.size();
  rep(i,ans.size())cout << ' ' << ans[i].second; puts("");
  return 0;
}
