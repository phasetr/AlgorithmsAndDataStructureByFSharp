// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/939304/mihchang/JavaScript
let cnt = 0;

function merge(A, left, mid, right) {
  const n1 = mid - left;
  const n2 = right - mid;
  const L = [];
  const R = [];
  for (let i = 0; i < n1; i++) {
    L[i] = A[left + i];
  }
  for (let i = 0; i < n2; i++) {
    R[i] = A[mid + i];
  }
  L[n1] = Number.MAX_VALUE;
  R[n2] = Number.MAX_VALUE;
  let i = 0;
  let j = 0;
  for (let k = left; k < right; k++) {
    cnt++;
    if (L[i] <= R[j]) {
      A[k] = L[i];
      i++;
    }
    else {
      A[k] = R[j];
      j++;
    }
  }
}
function mergeSort(A, left, right) {
  if (left + 1 < right) {
    const mid = Math.floor((left + right) / 2);
    mergeSort(A, left, mid);
    mergeSort(A, mid, right);
    merge(A, left, mid, right);
  }
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = input.split('\n');
const n = +lines.shift();
const A = lines.shift().trim().split(' ').map(function(i){return +i;});
mergeSort(A, 0, n);
console.log(A.join(' '));
console.log(cnt);
