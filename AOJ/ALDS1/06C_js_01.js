// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/939514/mihchang/JavaScript
function swap(A, i, j) {
  const tmp = A[i];
  A[i] = A[j];
  A[j] = tmp;
}

function partition(A, p, r) {
  const x = A[r].num;
  let i = p - 1;
  for (let j = p; j < r; j++) {
    if (A[j].num <= x) {
      i++;
      swap(A, i, j);
    }
  }
  swap(A, i + 1, r);

  return i + 1;
}

function sort(A, p, r) {
  if (p < r) {
    const q = partition(A, p, r);
    sort(A, p, q - 1);
    sort(A, q + 1, r);
  }
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = +lines.shift();
const line;
const A = [];
const C = {};
while ((line = lines.shift())) {
  const arr = line.split(' ');
  A.push({suit: arr[0], num: +arr[1]});

  const str = C[arr[1]] || '';
  C[arr[1]] = str + arr[0];
}

sort(A, 0, n - 1);

let isStable = true;
for (let i = 0; i < n; i++) {
  const e = A[i];
  const str = C[e.num + ''];
  if (str.substr(0, 1) != e.suit) {
    isStable = false;
    break;
  }
  C[e.num + ''] = str.substr(1);
}
console.log(isStable ? 'Stable' : 'Not stable');

A.forEach(function(e) {
  console.log(e.suit + ' ' + e.num);
});
