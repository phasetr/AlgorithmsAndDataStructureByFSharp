// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/6267770/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

var n = lines.shift();
n = parseInt(n,10);

var g = [];
var mincost = [];
var used = [];
for (var i = 0; i < n; i++) {
  g.push([]);
  mincost[i] = Infinity;
  used[i] = false;
  for (var j = 0; j < n; j++) {
    g[i][j] = Infinity;
  }
  g[i][i] = 0;
}
for (var i = 0; i < n; i++) {
  var t = lines[i].split(" ").map(Number);
  t.shift();
  var k = t.shift();
  for (var j = 0; j < k*2; j+=2) {
    var v = t[j],
        c = t[j+1];
    g[i][v] = c;
  }
}

mincost[0] = 0;

while (true) {
  var v = -1;
  for (var u = 0; u < n; u++) {
    if (!used[u] && (v === -1 || mincost[u] < mincost[v]))
      v = u;
  }
  if (v === -1) break;
  used[v] = true;
  for (var u = 0; u < n; u++) {
    mincost[u] = Math.min(mincost[u], g[v][u]+mincost[v]);
  }
}

for (var i = 0; i < n; i++) {
  console.log(`${i} ${mincost[i]}`);
}
