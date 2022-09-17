// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/2515468/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline)
  .map(function (line) { return line.split(' ').map(Number); });

n = line[0][0];
m = line[0][1];
q = line[m+1][0];

adj = new Array(n);
for (i = 0; i < n; i++) { adj[i] = {'list': [i, null], 'length': 1}; }

for (i = 1; i <= m; i++) {
  obj0 = adj[line[i][0]];
  obj1 = adj[line[i][1]];
  if (obj0 === obj1) { continue; }
  if (obj0.length <= obj1.length) {
    min = obj0;
    max = obj1;
  } else {
    min = obj1;
    max = obj0;
  }
  max.length += min.length;
  cur = min.list;
  while (cur[1] !== null) {
    adj[cur[0]] = max;
    cur = cur[1];
  }
  adj[cur[0]] = max;
  cur[1] = max.list;
  max.list = min.list;
  min.list = null;
  min.length = 0;
}

for (i = m+2; i < (m+2) + q; i++) {
  console.log((adj[line[i][0]] === adj[line[i][1]]) ? 'yes' : 'no');
}
