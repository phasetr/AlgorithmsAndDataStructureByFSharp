#include <iostream>
using namespace std;
long long N, W, w[109], v[109];
long long dp[109][100009];
int main() {
  cin >> N >> W;
  for (int i = 1; i <= N; i++) cin >> w[i] >> v[i];
  for (int i = 0; i <= N; i++) {
    for (int j = 0; j <= 100000; j++) dp[i][j] = 1000000000000000LL;
  }
  dp[0][0] = 0;
  for (int i = 1; i <= N; i++) {
    for (int j = 0; j <= 100000; j++) {
      if (j < v[i]) dp[i][j] = dp[i - 1][j];
      else dp[i][j] = min(dp[i - 1][j], dp[i - 1][j - v[i]] + w[i]);
    }
  }
  long long Answer = 0;
  for (int i = 0; i <= 100000; i++) {
    if (dp[N][i] <= W) Answer = i;
  }
  cout << Answer << endl;
  return 0;
}
