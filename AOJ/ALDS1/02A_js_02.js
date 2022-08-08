// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/937082/mihchang/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = lines[0];

const A = lines[1].split(' ').map(function(i) { return i - 0; });

const cnt = 0;
for (let i = 0; i < n; i++) {
  for (let j = n - 1; j > i; j--) {
    if (A[j] < A[j - 1]) {
      const tmp = A[j];
      A[j] = A[j - 1];
      A[j - 1] = tmp;
      cnt++;
    }
  }
}

console.log(A.join(' '));
console.log(cnt);
