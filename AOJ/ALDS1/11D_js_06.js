// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/6262494/sara3wati_3333/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var lines = (input.trim()).split("\n");

var line = lines.shift().split(" ").map(Number);
var n = line[0],
    m = line[1];
var parent = [],
    size = [];

var findRoot = function(x) {
  if (x !== parent[x]) {
    parent[x] = findRoot(parent[x]);
  }
  return parent[x];
};

var unite = function (x,y) {
  x = findRoot(x);
  y = findRoot(y);
  if (x === y) return;
  if (size[x] > size[y]) {
    parent[y] = x;
    size[x] += size[y];
  } else {
    parent[x] = y;
    size[y] += size[x];
  }
};

for (var i = 0; i < n; i++) {
  parent[i] = i;
  size[i] = 1;
}

for (var i = 0; i < m; i++) {
  var t = lines[i].split(" ").map(Number);
  var x = t[0],
      y = t[1];
  unite(x,y);
}
for (var i = m+1; i < lines.length; i++) {
  var t = lines[i].split(" ").map(Number);
  var x = t[0],
      y = t[1];
  console.log(findRoot(x) === findRoot(y) ? "yes" : "no");
}
