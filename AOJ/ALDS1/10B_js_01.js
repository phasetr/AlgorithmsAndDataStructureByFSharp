// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/6250769/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

var n = parseInt(lines[0]);
var mtr = lines[1].split(" ");
var dp = [...Array(n+1)].map(v => [...Array(n+1)].map(c => 0));
for (var i = 2; i <= n; i++) {
    mtr.push((lines[i].split(" ")[1]));
}

for (var i = 2; i <= n; i++) {
    for (var j = 1; j <= n-i+1; j++) {
        var end = j + i - 1;
        dp[j][end] = Infinity;
        for (var k = j; k < end; k++) {
            tmp = dp[j][k] + dp[k + 1][end] + mtr[j - 1] * mtr[k] * mtr[end];
            dp[j][end] = Math.min(dp[j][end], tmp);
        }
    }
}
console.log(dp[1][n]);
