// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/956061/mihchang/JavaScript
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

var items = lines.shift().trim().split(' ');
var n = +items[0];
var q = +items[1];

init(n);

var line;
while (line = lines.shift()) {
  var com = line.trim().split(' ');
  if (com[0] == 0) {
    union(com[1], com[2]);
  } else {
    console.log(isSame(com[1], com[2]) ? 1 : 0);
  }
}
