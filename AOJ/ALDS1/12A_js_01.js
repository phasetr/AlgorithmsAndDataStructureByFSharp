// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/950629/mihchang/JavaScript
var par = [];
function init(n) {
  for (var i = 0; i < n; i++) {
    par[i] = i;
  }
}
function find(x) {
  if (par[x] == x) return x;
  return par[x] = find(par[x]);
}
function isSame(x, y) {
  return find(x) == find(y);
}
function union(x, y) {
  x = find(x);
  y = find(y);
  if (x == y) return;
  par[x] = y;
}

var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var lines = input.split('\n');

var n = +lines.shift();

var es = [];
for (var y = 0; y < n; y++) {
  var xs = lines.shift().trim().split(' ').map(function(n){return +n;});
  for (var x = y + 1; x < n; x++) {
    var cost = xs[x];
    if (cost == -1) continue;
    es.push({cost: cost, v1: x, v2: y});
  }
}
es.sort(function(a, b){return a.cost - b.cost;});

init(n);
var costs = 0;
var e;
while (e = es.shift()) {
  if (!isSame(e.v1, e.v2)) {
    costs += e.cost;
    union(e.v1, e.v2);
  }
}
console.log(costs);
