// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2431268/keisuketsushima/JavaScript
(function(stdin) {
  var lines = stdin.trim().split('\n');
  var n = parseInt(lines.shift(), 10);
  var nodes = [];
  var color = [];
  lines.forEach(function(node) {
    var adjs = node.split(' ').map(Number).slice(2);
    nodes.push(adjs);
    color.push('WHITE');
  });
  var time = 0;
  var d = [];
  var f = [];
  function dfs(k) {
    var id = k - 1;
    color[id] = 'GRAY';
    d[id] = ++time;
    nodes[id].forEach(function(i) {
      if (color[i - 1] == 'WHITE') {
        dfs(i);
      }
    });
    color[id] = 'BLACK';
    f[id] = ++time;
  }
  for (var i = 1; i <= n; i++) {
    if (color[i - 1] != 'BLACK') {
      dfs(i);
    }
  }
  for (var i = 0; i < n; i++) {
    console.log([i + 1, d[i], f[i]].join(' '));
  }
})(require('fs').readFileSync('/dev/stdin', 'utf8'));
