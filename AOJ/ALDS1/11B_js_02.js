// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/950105/mihchang/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var lines = input.split('\n');

var n = +lines.shift();

var g = [[]];
for (var i = 1; i <= n; i++) {
  g.push([]);
  for (var j = 1; j <= n; j++) {
    g[i][j] = 0;
  }
}

for (var i = 1; i <= n; i++) {
  var u = lines.shift().split(' ').map(function(n){return +n;});
  var id = u[0];
  var k = u[1];

  for (var j = 0; j < k; j++) {
    g[i][u[2 + j]] = 1;
  }
}

var ts = 1;
var v = [];
for (var i = 1; i <= n; i++) {
  v[i] = {d: 0, f: 0};
}
function visit(id) {
  if (v[id].d) return;

  v[id].d = ts++;

  for (var i = 1; i <= n; i++) {
    if (g[id][i] == 1) {
      visit(i);
    }
  }

  v[id].f = ts++;
}
for (var i = 1; i <= n; i++) {
  visit(i);
}

for (var id = 1; id <= n; id++) {
  console.log(id, v[id].d, v[id].f);
}
