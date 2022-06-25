// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/955561/mihchang/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var lines = input.split('\n');

var n = +lines.shift();
var G = [];
for (var i = 0; i < n; i++) {
  G.push([]);
  for (var j = 0; j < n; j++) {
    G[i][j] = Number.POSITIVE_INFINITY;
  }
  G[i][i] = 0;
}
for (var i = 0; i < n; i++) {
  var u = lines.shift().trim().split(' ').map(function(n){return +n;});
  var id = u[0];
  var k = u[1];
  for (var j = 0; j < k; j++) {
    var adj = u[2 + j * 2];
    var cost = u[2 + j * 2 + 1];
    G[i][adj] = cost;
  }
}

var cost = [0];
for (var i = 1; i < n; i++) {
  cost.push(Number.POSITIVE_INFINITY);
}
var visited = {};
while (true) {
  var u = -1;
  for (var i = 0; i < n; i++) {
    if (!visited[i] && (u == -1 || cost[i] < cost[u])) {
      u = i;
    }
  }
  if (u == -1) {
    break;
  }
  visited[u] = true;

  for (var i = 0; i < n; i++) {
    cost[i] = Math.min(cost[i], cost[u] + G[u][i]);
  }
}

for (var i = 0; i < n; i++) {
  console.log(i, cost[i]);
}
