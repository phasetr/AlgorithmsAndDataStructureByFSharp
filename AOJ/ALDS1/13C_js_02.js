// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/2545078/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

const SIZE = 4;

board = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline)
  .map(function (line) { return line.split(' ').map(Number); });

goal = [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,0]];

function find(num) {
  var i, j, res = [,];
  for (i = 0; i < SIZE; i++) {
    for (j = 0; j < SIZE; j++) {
      if (board[i][j] == num) {
        res[0] = i;
        res[1] = j;
      }
    }
  }
  return res;
}

function switch_board(row1, col1, row2, col2) {
  var tmp = board[row1][col1];
  board[row1][col1] = board[row2][col2];
  board[row2][col2] = tmp;
}

distance = new Array(SIZE*SIZE);
for (i = 0; i < SIZE*SIZE; i++) distance[i] = [-1, -1];

function get_distance() {
  var sum = 0, d = distance, i, j;
  for (i = 0; i < SIZE; i++) {
    for (j = 0; j < SIZE; j++) {
      d[board[i][j]][0] = i;
      d[board[i][j]][1] = j;
    }
  }
  for (i = 0; i < SIZE; i++) {
    for (j = 0; j < SIZE; j++) {
      d[goal[i][j]][0] -= i;
      d[goal[i][j]][1] -= j;
    }
  }
  for (i = 1; i < SIZE*SIZE; i++)
    sum += Math.abs(d[i][0]) + Math.abs(d[i][1]);
  return sum;
}

const INITDIR = 0, N = 1, S = 2, W = 3, E = 4;

function iddfs(step, max, row, col, dir) {
  var i, j;
  //console.log("step=%d, row=%d, col=%d, dir=%d, distance=%d",
  //  step, row, col, dir, get_distance());
  if (step === max) {
    for (i = 0; i < SIZE; i++)
      for (j = 0; j < SIZE; j++)
        if (board[i][j] !== goal[i][j]) return false;
    return true;
  }

  if (step + get_distance() > max) return false;

  if (dir !== W && row > 0) {
    switch_board(row, col, row-1, col);
    if (iddfs(step + 1, max, row-1, col, E)) return true;
    switch_board(row, col, row-1, col);
  }
  if (dir !== E && row < 3) {
    switch_board(row, col, row+1, col);
    if (iddfs(step + 1, max, row+1, col, W)) return true;
    switch_board(row, col, row+1, col);
  }
  if (dir !== S && col > 0) {
    switch_board(row, col, row, col-1);
    if (iddfs(step + 1, max, row, col-1, N)) return true;
    switch_board(row, col, row, col-1);
  }
  if (dir !== N && col < 3) {
    switch_board(row, col, row, col+1);
    if (iddfs(step + 1, max, row, col+1, S)) return true;
    switch_board(row, col, row, col+1);
  }
  return false;
}

rc = find(0);
for (i = 0; i <= 45; i++)
  if (iddfs(0, i, rc[0], rc[1], INITDIR)) break;
console.log(i);
