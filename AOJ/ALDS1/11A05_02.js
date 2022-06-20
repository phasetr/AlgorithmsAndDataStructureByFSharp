// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/4082461/takumi_yamamoto/JavaScript
function main(_stdin) {
  const stdin = _stdin.trim().split('\n');
  const n = Number(stdin.shift());
  const G = [];
  for (let i = 0; i < n; i++) {
    G.push(new Array(n).fill(0));
  }

  for (let i = 0; i < n; i++) {
    const d = stdin[i].trim().split(' ').map(Number);
    const r = d.slice(2);
    if(r.length) {
      for (let item of r) {
        G[d[0] - 1][item - 1] = 1;
      }
    }
    console.log(G[i].join(' '));
  }
}
main(require('fs').readFileSync('/dev/stdin', 'utf8'));
