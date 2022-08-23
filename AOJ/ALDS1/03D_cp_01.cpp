// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/1464607/yudedako/C++
#include <iostream>
#include <stack>
#include <algorithm>

int main(){
  std::stack<int> State;
  std::stack<std::pair<int, int> > Lake;
  char ch;
  int sum, s;
  for (int i = 0; (std::cin >> ch); i ++){
    if (ch == '\\')State.push(i);
    else if (ch == '/' and State.size() > 0){
      sum += s = i - State.top();
      while((Lake.size() > 0) and (State.top() < Lake.top().first)){
      s += Lake.top().second;
      Lake.pop();
      }
      Lake.push(std::make_pair(State.top(), s));
      State.pop();
    }
  }
  std::stack<int> ans;
  while (Lake.size() > 0){ans.push(Lake.top().second);Lake.pop();}
  std::cout << sum << "\n";
  std::cout << ans.size();
  while (ans.size() > 0){std::cout << " " << ans.top();ans.pop();}
  std::cout << std::endl;
}
