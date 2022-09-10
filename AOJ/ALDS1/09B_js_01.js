// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/2418645/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

A = require('fs').readFileSync(config.input, 'ascii').split(config.newline, 2);
A = A[1].split(' ').map(Number);
A.unshift(null);

buildMaxHeap(A);

A[0] = '';
console.log(A.join(' '));

function maxHeapify(A, i) {
  var left, right, largest, tmp;
  left = 2 * i;
  if (left >= A.length) left = null;
  right = 2 * i + 1;
  if (right >= A.length) right = null;
  largest = i;
  if (left && A[left] > A[largest]) largest = left;
  if (right && A[right] > A[largest]) largest = right;
  if (largest !== i) {
    tmp = A[i];
    A[i] = A[largest];
    A[largest] = tmp;
    maxHeapify(A, largest);
  }
}

function buildMaxHeap(A) {
  for (var i = Math.floor(A.length - 1); i >= 1; i--)
    maxHeapify(A, i);
}
