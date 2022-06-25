// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3513397/s1250042/JavaScript
const [WHITE, BLACK] = [0, 1];

(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  const range_n = Array.from(Array(n), (e, i) => i);
  const adj = [];
  let x, k, arr;
  lines.forEach((l, i) => {
    adj[i] = [].concat(range_n).fill(Infinity);
    [x, k, ...arr] = l.split(' ').map(Number);
    for (let j = 0; j < k; j++) adj[i][arr[2 * j]] = arr[2 * j + 1];
  });

  const dist = [];
  const color = [];
  for (let i = 0; i < n; i++) {
    dist[i] = Infinity;
    color[i] = WHITE;
  }
  dist[0] = 0;

  let mincost, u = 0, min = [].concat(range_n).fill(Infinity);
  min[0] = 0;

  while (true) {
    adj[u].forEach((v, i) => {
      if (color[i] !== BLACK && min[u] + v < min[i]) min[i] = min[u] + v;
    });

    mincost = range_n.reduce((m, i) => {
      if (color[i] === BLACK || min[i] >= m) return m;
      return min[u = i];
    }, Infinity);

    if (mincost === Infinity) break;

    color[u] = BLACK;
  }

  console.log(min.map((e, i) => `${i} ${e}`).join('\n'));
})();
