// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/3065104/s1250042/JavaScript
var N = 8;
var row = Array.from(Array(N), () => -1);
var col = new Array(N);
var dpos = new Array(2 * N - 1);
var dneg = new Array(2 * N - 1);

function search(r) {
  if (r === N) {
    printBoard();
    return true;
  }

  if (row[r] !== -1) return search(r + 1);
  for (let c = 0; c < N; c++) {
    if (col[c] || dpos[r + c] || dneg[r - c + N - 1]) continue;
    changeBoard(r, c, true);
    search(r + 1);
    changeBoard(r, c, false);
  }
  return false;
}

function changeBoard(r, c, flg) {
  if (flg) {
    row[r] = c;
  } else {
    row[r] = -1;
  }
  col[c] = dpos[r + c] = dneg[r - c + N - 1] = flg;
}

function printBoard() {
  for (let r = 0; r < N; r++) {
    for (let c = 0; c < N; c++) {
      process.stdout.write(row[r] === c ? 'Q' : '.');
    }
    console.log();
  }
}

(function main() {
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const k = Number(lines.shift());

  let r, c;
  for (let i = 0; i < k; i++) {
    [r, c] = lines.shift().split(' ').map(Number);
    changeBoard(r, c, true);
  }
  search(0);
})();
