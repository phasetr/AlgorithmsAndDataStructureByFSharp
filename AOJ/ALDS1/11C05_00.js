// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/3045905/s1250042/JavaScript
function bfs(adjs) {
  const WHITE = 0, GRAY = 1, BLACK = 2;
  const color = Array.from(adjs, () => WHITE);
  const d = [0];
  for (let i=1; i<adjs.length; i++) { d[i] = -1; }

  const queue = [0];
  let u;
  while ((u = queue.shift()) !== undefined) {
    adjs[u].forEach(v => {
      if (color[v] === WHITE) {
        color[v] = GRAY;
        d[v] = d[u] + 1;
        queue.push(v);
      }
    });
    color[u] = BLACK;
  }
  return d;
}

function solve(lines) {
  const n = Number(lines.shift());
  const adjs = Array.from(Array(n), () => []);
  lines.forEach((l, i) => {
    const ls = l.split(" ");
    const node = Number(ls[0]);
    ls.splice(2).forEach(e => adjs[node-1].push(Number(e)-1));
  });
  const d = bfs(adjs);
  const vs = [];
  for (let i = 0; i < n; i++) {
    vs.push(`${i+1} ${d[i]}`);
  }
  return vs;
}

(() => {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  solve(lines).forEach(s => console.log(s));
})();

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
console.log(compare(solve(["4","1 2 2 4","2 1 4","3 0","4 1 3"]),["1 0","2 1","3 2","4 1"]));
