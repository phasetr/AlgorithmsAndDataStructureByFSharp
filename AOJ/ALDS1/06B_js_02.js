// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/939461/mihchang/JavaScript
function partition(A, p, r) {
  const x = A[r];
  let i = p - 1;
  for (let j = p; j < r; j++) {
    if (A[j] <= x) {
      i++;
      var tmp = A[i];
      A[i] = A[j];
      A[j] = tmp;
    }
  }
  const tmp = A[i + 1];
  A[i + 1] = A[r];
  A[r] = tmp;
  return i + 1;
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = +lines.shift();
const A = lines.shift().split(' ').map(function(i){return +i;});
const idx = partition(A, 0, A.length - 1);
A[idx] = '[' + A[idx] + ']';
console.log(A.join(' '));
