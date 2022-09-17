// https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_12_A
function solve(n,lines){
  const par = [];
  function init(n) {
    for (var i = 0; i < n; i++) { par[i] = i; }
  }
  function find(x) { return (par[x] === x) ? x : par[x] = find(par[x]); }
  function isSame(x, y) { return find(x) == find(y); }
  function union(x, y) {
    x = find(x);
    y = find(y);
    if (x == y) { return; }
    par[x] = y;
  }

  const es = [];
  for (let y=0; y<n; y++) {
    const xs = lines.shift().trim().split(' ').map((n) => { return +n; });
    for (let x = y+1; x<n; x++) {
      const cost = xs[x];
      if (cost === -1) { continue; }
      es.push({cost: cost, v1: x, v2: y});
    }
  }
  es.sort(function(a, b){return a.cost - b.cost;});

  init(n);
  let cost = 0;
  let e = es.shift();
  while (e) {
    if (!isSame(e.v1, e.v2)) {
      cost += e.cost;
      union(e.v1, e.v2);
    }
    e = es.shift();
  }
  return cost;
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
const lines = input.split('\n');
const n = Number(lines.shift());
console.log(solve(n,lines));

console.log(solve(5,[" -1 2 3 1 -1"," 2 -1 -1 4 -1"," 3 -1 -1 1 1"," 1 4 1 -1 3"," -1 -1 1 3 -1"]) === 5);
