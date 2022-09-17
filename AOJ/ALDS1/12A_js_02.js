// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/2517795/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

A = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline)
  .map(function (line) { return line.trim().split(' ').map(Number); });
n = Number(A.shift()[0]);

cnt = 1;
cost = 0;
conn = new Array(n);
conn[0] = true;
for (i = 1; i < n; i++) conn[i] = false;

while (cnt < n) {
  min = Number.MAX_VALUE;
  for (i in conn) {
    if (!conn[i]) continue;
    Ai = A[i];
    for (j in conn) {
      if (conn[j]) continue;
      if (Ai[j] !== -1 && Ai[j] < min) {
        min = Ai[j];
        min_j = j;
      }
    }
  }
  conn[min_j] = true;
  cost += min;
  cnt++;
}

console.log(cost);
