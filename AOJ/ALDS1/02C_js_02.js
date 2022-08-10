// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/937108/mihchang/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = lines[0];

const A1 = lines[1].split(' ');
for (let i = 0; i < n; i++) {
  for (let j = n - 1; j > i; j--) {
    if (A1[j].split('')[1] < A1[j - 1].split('')[1]) {
      const tmp = A1[j];
      A1[j] = A1[j - 1];
      A1[j - 1] = tmp;
    }
  }
}
console.log(A1.join(' '));
console.log('Stable');

const A2 = lines[1].split(' ');
for (let i = 0; i < n; i++) {
  const min = i;
  for (let j = i; j < n; j++) {
    if (A2[j].split('')[1] < A2[min].split('')[1]) {min = j;}
  }
  if (min == i) {continue;}
  const tmp = A2[i];
  A2[i] = A2[min];
  A2[min] = tmp;
}

console.log(A2.join(' '));
console.log(A1.join(' ') == A2.join(' ') ? 'Stable' : 'Not stable');
