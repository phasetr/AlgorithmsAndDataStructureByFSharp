// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/2552922/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

line = require('fs').readFileSync(config.input, 'ascii')
  .split(config.newline);
line[0] = line[0].split(' ').map(Number);
H = line[0][0];
W = line[0][1];
field = line.slice(1, 1+H);
line[1+H] = line[1+H].split(' ').map(Number);
R = line[1+H][0];
C = line[1+H][1];
pat = line.slice(1+H+1, 1+H+1+R);

if (H < R || W < C) process.exit();

hash = {};
cnt = 0;
function register(str) {
  if (!hash.hasOwnProperty(str)) {
    hash[str] = cnt;
    return cnt++;
  }
  return hash[str];
}

matrix = field.map(function (str) {
  var res, i;
  res = [];
  for (i = 0; i <= W-C; i++) res.push(register(str.slice(i, i+C)));
  return res;
});
pat = pat.map(register);

for (i = 0; i <= H-R; i++) {
  for (j = 0; j <= W-C; j++) {
    flag = true;
    for (k = 0; k < R; k++) {
      if (matrix[i+k][j] !== pat[k]) {
        flag = false;
        break;
      }
    }
    if (flag) console.log(i, j);
  }
}
