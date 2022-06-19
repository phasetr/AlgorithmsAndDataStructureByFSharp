// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/3040329/s1250042/JavaScript
(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  const MAX = 1000;
  const c = Array.from(Array(MAX + 1), () => []);

  let i, j, X, Y, xlen, ylen, maxlen;
  while ((X = lines.shift()) && (Y = lines.shift())) {
    xlen = X.length;
    ylen = Y.length;
    for (i = 0; i <= xlen; i++) c[i][0] = 0;
    for (j = 0; j <= ylen; j++) c[0][j] = 0;

    for (i = 1; i <= xlen; i++) {
      for (j = 1; j <= ylen; j++) {
        if (X[i - 1] === Y[j - 1]) c[i][j] = c[i - 1][j - 1] + 1;
        else c[i][j] = Math.max(c[i - 1][j], c[i][j - 1]);
      }
    }
    console.log(c[xlen][ylen]);
  }
})();

