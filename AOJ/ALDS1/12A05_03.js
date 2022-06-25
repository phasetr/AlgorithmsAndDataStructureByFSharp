// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/6265221/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

var n = lines.shift();
n = parseInt(n,10);
var g = [];
var mincost = [];
var used = [];
for (var i = 0; i < n; i++) {
  var t = lines[i].split(" ").map(Number);
  t.shift();
  g.push(t);
  mincost[i] = Infinity;
  used[i] = false;
}

mincost[0] = 0;
sum = 0;

while (true) {
  var v = -1;
  for (var u = 0; u < n; u++) {
    if (!used[u] && (v === -1 || mincost[u] < mincost[v])) { v = u; }
  }
  if (v === -1) { break; }
  used[v] = true;
  sum += mincost[v];
  for (var u = 0; u < n; u++) {
    if (g[v][u] !== -1) { mincost[u] = Math.min(mincost[u], g[v][u]); }
  }
}
console.log(sum);
