// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/3045905/s1250042/JavaScript
(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  const adjLists = Array.from(Array(n), () => []);
  const d = [];
  lines.forEach((l, i) => l.split(' ').splice(2).forEach(e => adjLists[i].push(e-1)));
  bfs(adjLists, d);
  for (let i = 0; i < n; i++) {
    console.log(i + 1, d[i]);
  }
})();

function bfs(adjLists, d) {
  const WHITE = 0, GRAY = 1, BLACK = 2;
  const color = Array.from(adjLists, () => WHITE);
  d[0] = 0;
  for (let i = 1; i < adjLists.length; i++) d[i] = -1;
  queue = [0];
  let u;
  while ((u = queue.shift()) !== undefined) {
    adjLists[u].forEach(v => {
      if (color[v] === WHITE) {
        color[v] = GRAY;
        d[v] = d[u] + 1;
        queue.push(v);
      }
    });
    color[u] = BLACK;
  }
}
