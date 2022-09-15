// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/2515159/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline);
n = Number(line.shift());
adj = {};
for (i in line) {
  ary = line[i].split(' ');
  j = ary.shift();
  ary.shift();
  adj[j] = ary;
}

node = new Array(n + 1);
node[0] = null;
node[1] = 0;
for (i = 2; i <= n; i++) node[i] = -1;

d = 1;
do {
  cnt = 0;
  for (i = 1; i <= n; i++) {
    if (node[i] !== d - 1) continue;
    for (j in adj[i]) {
      k = adj[i][j];
      if (node[k] === -1) {
        node[k] = d;
        cnt++;
      }
    }
  }
  d++;
} while (cnt !== 0);

for (i = 1; i <= n; i++)
  console.log("%d %d", i, node[i]);
