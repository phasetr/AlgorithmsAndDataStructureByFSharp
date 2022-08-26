// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2398794/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
const config = { input: '/dev/stdin', newline: '\n' }; // linux
const line = require('fs').readFileSync(config.input, 'ascii').split(config.newline, 4);
const A = line[1].split(' ').map(Number);
const m = line[3].split(' ').map(Number);
const comb = [0];
for (const i in A) {
  const comb_i = [];
  for (const j in comb) {
    if (comb.indexOf(A[i] + comb[j]) === -1) comb_i.push(A[i] + comb[j]);
  }
  comb = comb.concat(comb_i);
}

for (const i in m) {
  if (comb.indexOf(m[i]) !== -1) console.log('yes');
  else console.log('no');
}
