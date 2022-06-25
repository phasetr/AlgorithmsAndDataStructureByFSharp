// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3513397/s1250042/JavaScript
function solve(n,lines) {
  const [WHITE,BLACK] = [0,1];
  const rN = Array.from(Array(n), (_,i) => i);
  const adj = [];
  lines.forEach((l,i) => {
    adj[i] = [].concat(rN).fill(Infinity);
    const [x, k, ...arr] = l.split(' ').map(Number);
    for (let j = 0; j < k; j++) { adj[i][arr[2 * j]] = arr[2 * j + 1]; }
  });

  const dist = [];
  const color = [];
  rN.forEach(i => { dist[i] = Infinity; color[i] = WHITE; });
  dist[0] = 0;

  let mincost, u = 0, mins = [].concat(rN).fill(Infinity);
  mins[0] = 0;

  while (true) {
    adj[u].forEach((v,i) => {
      if (color[i] !== BLACK && mins[u] + v < mins[i]) { mins[i] = mins[u] + v; }
    });
    mincost = rN.reduce(
      (m,i) => { return (color[i] === BLACK || mins[i] >= m) ? m : mins[u = i]; }
      , Infinity);
    if (mincost === Infinity) { break; }
    color[u] = BLACK;
  }
  return mins;
}

(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  solve(n,lines).forEach((e,i) => console.log(`${i} ${e}`));
})();

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
console.log(compare(solve(5,["0 3 2 3 3 1 1 2","1 2 0 2 3 4","2 3 0 3 3 1 4 1","3 4 2 1 0 1 1 4 4 3","4 2 2 1 3 3"]).map((e,i) => `${i} ${e}`),["0 0","1 2","2 2","3 1","4 3"]));
