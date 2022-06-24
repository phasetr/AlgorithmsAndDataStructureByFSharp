// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/2431287/keisuketsushima/JavaScript
(function(stdin) {
  var lines = stdin.trim().split('\n');
  var numbers = lines.shift().split(' ').map(Number);
  var n = numbers.shift();
  var m = numbers.shift();
  var nodes = [];
  var color = [];
  for (var i = 0; i < n; i++) {
    nodes.push([]);
    color.push(null);
  }
  for (var i = 0; i < m; i++) {
    var node = lines.shift().split(' ').map(Number);
    nodes[node[0]].push(node[1]);
    nodes[node[1]].push(node[0]);
  }
  function dfs(n, id) {
    var stack = [];
    color[n] = id;
    stack.push(n);
    while (stack.length > 0) {
      var next = stack.shift();
      for (var i = 0; i < nodes[next].length; i++) {
        if (!color[nodes[next][i]]) {
          color[nodes[next][i]] = id;
          stack.push(nodes[next][i]);
        }
      }
    }
  }
  var id = 1;
  for (var i = 0; i < n; i++) {
    if (!color[i]) {
      dfs(i, id++);
    }
  }
  var q = parseInt(lines.shift(), 10);
  lines.forEach(function(relation) {
    var edge = relation.split(' ').map(Number);
    console.log(color[edge[0]] === color[edge[1]] ? "yes" : "no");
  });
})(require('fs').readFileSync('/dev/stdin', 'utf8'));
