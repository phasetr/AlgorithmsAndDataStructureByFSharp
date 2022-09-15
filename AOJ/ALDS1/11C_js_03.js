// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/2431274/keisuketsushima/JavaScript
(function(stdin) {
  var lines = stdin.trim().split('\n');
  var n = parseInt(lines.shift(), 10);
  var nodes = [];
  var color = [];
  var d = [];
  lines.forEach(function(node) {
    var adjs = node.split(' ').map(Number).slice(2);
    nodes.push(adjs);
    color.push('WHITE');
    d.push(-1);
  });
  var queue = [];
  color[0] = 'GRAY';
  d[0] = 0;
  queue.push(1);
  while (queue.length > 0) {
    var i = queue.shift();
    nodes[i - 1].forEach(function(j) {
      if (color[j - 1] == 'WHITE') {
        color[j - 1] = 'GRAY';
        d[j - 1] = d[i - 1] + 1;
        queue.push(j);
      }
    });
  }
  d.forEach(function(dist, i) {
    console.log([i + 1, dist].join(' '));
  });
})(require('fs').readFileSync('/dev/stdin', 'utf8'));
