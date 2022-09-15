// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/3045722/s1250042/JavaScript
function dfs(adjs) {
  const WHITE = 0, GRAY = 1, BLACK = 2;
  const size = adjs.length;
  const color = Array.from(adjs, () => WHITE);

  const d = [];
  const f = [];

  let time = 0;
  function visit(u) {
    color[u] = GRAY;
    d[u] = ++time;
    adjs[u].forEach(v => { if (color[v] === WHITE) { visit(v); } });
    color[u] = BLACK;
    f[u] = ++time;
  }
  adjs.forEach((e, u) => { if (color[u] === WHITE) visit(u); });
  return {d,f};
}

function solve(lines) {
  const n = Number(lines.shift());
  const adjs = Array.from(Array(n), () => []);
  lines.forEach(l => {
    const ls = l.split(' ');
    const node = Number(ls[0]);
    ls.splice(2).forEach(e => adjs[node-1].push(Number(e)-1));
  });

  const {d,f} = dfs(adjs);
  const vs = [];
  for (let i = 0; i < n; i++) {
    vs.push(`${i + 1} ${d[i]} ${f[i]}`);
  }
  return vs;
}

(() => {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  solve(lines).forEach(s => process.stdout.write(`${s}\n`));
})();

function compare(xa,ya) { return JSON.stringify(xa) === JSON.stringify(ya); }
console.log(compare(solve(["4","1 1 2","2 1 4","3 0","4 1 3"]),['1 1 8','2 2 7','3 4 5','4 3 6']));
console.log(compare(solve(["6","1 2 2 3","2 2 3 4","3 1 5","4 1 6","5 1 6","6 0"]),["1 1 12","2 2 11","3 3 8","4 9 10","5 4 7","6 5 6"]));
console.log(compare(solve(["6","1 2 2 4","2 1 5","3 2 5 6","4 0","5 1 4","6 1 6"]),["1 1 8","2 2 7","3 9 12","4 4 5","5 3 6","6 10 11"]));
