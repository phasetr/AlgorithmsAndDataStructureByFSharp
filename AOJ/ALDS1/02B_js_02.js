// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/937094/mihchang/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = lines[0];
const A = lines[1].split(' ').map(function(i) { return i - 0;});

const cnt = 0;
for (let i = 0; i < n; i++) {
  const min = i;
  for (let j = i; j < n; j++) {
    if (A[j] < A[min]){min = j;}
  }
  if (min == i){continue;}

  const tmp = A[i];
  A[i] = A[min];
  A[min] = tmp;
  cnt++;
}

console.log(A.join(' '));
console.log(cnt);
