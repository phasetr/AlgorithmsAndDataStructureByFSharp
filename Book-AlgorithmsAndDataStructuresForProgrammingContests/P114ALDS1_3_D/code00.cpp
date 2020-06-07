#include <algorithm>
#include <iostream>
#include <stack>
#include <string>
#include <vector>
using namespace std;

int main() {
  stack<int> S1;

  /**
   * first: left most position of "\" for the puddle
   * second: (temporal) area
   */
  stack<pair<int, int>> S2;
  char ch;
  int sum = 0;

  for (int i = 0; cin >> ch; i++) {
    if (ch == '\\') {
      S1.push(i);
    } else if (ch == '/' && S1.size() > 0) {
      int j = S1.top();
      S1.pop();

      // 1 段ずつ対応を取っていく
      // 「\/」ペアで面積 1 になる分を差し引けば、
      // 1 段分の追加で面積が i-j 増える
      sum += i - j;
      int a = i - j;

      // 小さな水たまりを統合する処理
      // 統合処理が走る条件が if の内容
      while (S2.size() > 0 && S2.top().first > j) {
        a += S2.top().second;
        // 統合処理した小さな水たまりは捨てる
        S2.pop();
      }

      // 必要なら統合処理をしたうえで水たまりを追加
      S2.push(make_pair(j, a));
    }
  }

  // 最終出力用に S2 の順番を反転させるだけ
  vector<int> ans;
  int t = 0;
  while (S2.size() > 0) {
    ans.push_back(S2.top().second);
    S2.pop();
  }
  reverse(ans.begin(), ans.end());
  cout << sum << endl;
  cout << ans.size();
  for (int i = 0; i < ans.size(); i++) {
    cout << " ";
    t += ans[i];
    cout << ans[i];
  }
  cout << endl;

  return 0;
}
