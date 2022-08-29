// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/939453/mihchang/JavaScript
function csort(A, B, k) {
  const C = [];
  for (let i = 0; i <= k; i++) {
    C[i] = 0;
  }
  for (let j = 0; j <= A.length; j++) {
    C[A[j]]++;
  }
  for (let i = 1; i <= k; i++) {
    C[i] += C[i - 1];
  }
  for (let j = A.length - 1; j >= 0; j--) {
    B[C[A[j]] - 1] = A[j];
    C[A[j]]--;
  }
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = +lines.shift();
const A = lines.shift().split(' ').map(function(i){return +i;});
const B = [];
csort(A, B, 10000);
console.log(B.join(' '));
