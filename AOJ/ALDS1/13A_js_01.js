// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/6268729/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");

const N = 8;
const row = [...Array(N)].map(n => -1);
const col = new Array(N);
const top_r_to_bottom_l = new Array(2*N-1);
const top_l_to_bottom_r = new Array(2*N-1);
const g = [...Array(N)].map(n => [...Array(N)]);
const place_a_piece = function (r,c,flg) {
  if (flg) { row[r] = c; } else { row[r] = -1; }
  col[c] = top_r_to_bottom_l[r + c] = top_l_to_bottom_r[r - c + N - 1] = flg;
};

const make_board = function () {
  for (let r = 0; r < N; r++) {
    for (let c = 0; c < N; c++) {
      if (row[r] === c) { g[r][c] = "Q"; }
      else { g[r][c] = "."; }
    }
  }
};

const recursional_search = function (r) {
  if (r === N) {
    make_board();
    return true;
  }

  if (row[r] !== -1) { return recursional_search(r + 1); }

  for (let c = 0; c < N; c++) {
    if (col[c] || top_r_to_bottom_l[r + c] || top_l_to_bottom_r[r - c + N - 1]) continue;
    place_a_piece(r, c, true);
    recursional_search(r + 1);
    place_a_piece(r, c, false);
  }
  return false;
};

const k = Number(lines.shift());

for (let i = 0; i < k; i++) {
  [r,c] = lines[i].split(" ").map(Number);
  place_a_piece(r,c,true);
}

recursional_search(0);
for (let i = 0; i < N; i++) {
  console.log(g[i].join(""));
}
