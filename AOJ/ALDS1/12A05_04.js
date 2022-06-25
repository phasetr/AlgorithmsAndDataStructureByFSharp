// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/3054022/s1250042/JavaScript
const [WHITE, BLACK] = [0, 1];

(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  const adj = lines.map((e, i) => e.trim().split(' ').map(n => n == -1 && Infinity || Number(n)));
  const range_n = Array.from(Array(n), (e, i) => i);

  const dist = [];
  const color = [];
  for (let i = 0; i < n; i++) {
    dist[i] = Infinity;
    color[i] = WHITE;
  }
  dist[0] = 0;

  let mincost, u, sum = 0;

  while (true) {
    mincost = range_n.reduce((min, i) => {
      if (color[i] === BLACK || dist[i] >= min) { return min; }
      return dist[u = i];
    }, Infinity);

    if (mincost === Infinity) { break; }

    sum += mincost;
    color[u] = BLACK;

    adj[u].forEach((v, i) => {
      if (color[i] !== BLACK && dist[i] > v) { dist[i] = v; }
    });
  }

  console.log(sum);
})();
