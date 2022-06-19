// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/3040329/s1250042/JavaScript
function solve(n,xa) {
  const MAX = 1000;
  const c = Array.from(Array(MAX + 1), () => []);

  return [...Array(n)].map((_, i) => i)
    .map(m => {
      const X = xa.shift();
      const Y = xa.shift();
      const lx = X.length;
      const ly = Y.length;
      for (let i=0; i<=lx; i++) { c[i][0] = 0; }
      for (let j=0; j<=ly; j++) { c[0][j] = 0; }

      for (let i=1; i<=lx; i++) {
        for (let j = 1; j<=ly; j++) {
          if (X[i-1] === Y[j-1]) { c[i][j] = c[i-1][j-1] + 1; }
          else { c[i][j] = Math.max(c[i-1][j], c[i][j-1]); }
        }
      }
      return c[lx][ly];});
}

(() => {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  solve(n,lines).forEach(v => console.log(v));
})();

function compareArray(xa,ya) {
  return [...Array(xa.length)].map((_, i) => i)
    .map(m => xa[m] === ya[m])
    .every(b => b);
}
console.log(compareArray(solve(3,["abcbdab","bdcaba","abc","abc","abc","bc"]), [4,3,2]));
