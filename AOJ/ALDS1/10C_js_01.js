// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/949468/mihchang/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var lines = input.split('\n');

var n = +lines.shift();

while (n--) {
  var X = lines.shift().split('');
  var Y = lines.shift().split('');

  var dp = [];
  for (var i = 0; i <= X.length; i++) {
    dp.push([]);
    for (var j = 0; j <= Y.length; j++) {
      dp[i][j] = 0;
    }
  }

  for (var i = 0; i < X.length; i++) {
    for (var j = 0; j < Y.length; j++) {
      if (X[i] == Y[j]) {
        dp[i + 1][j + 1] = dp[i][j] + 1;
      } else {
        dp[i + 1][j + 1] = Math.max(dp[i][j + 1], dp[i + 1][j]);
      }
    }
  }
  console.log(dp[X.length][Y.length]);
}
