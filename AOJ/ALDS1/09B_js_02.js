// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/5133620/s1250087/JavaScript
const line = require('fs').readFileSync('/dev/stdin', 'utf-8').split('\n');

const maxHeapify = (arr, i) => {
  const l = i * 2;
  const r = l + 1;
  let max;

  if (l <= arr.length && arr[l-1] > arr[i-1]) {
    max = l;
  } else {
    max = i;
  }
  if (r <= arr.length && arr[r-1] > arr[max-1]) {
    max = r;
  }

  if (max !== i) {
    const tmp = arr[i-1];
    arr[i-1] = arr[max-1];
    arr[max-1] = tmp;
    maxHeapify(arr, max);
  }
};

const buildMaxHeap = arr => {
  for (let i = Math.floor(arr.length / 2); i > 0; i--) {
    maxHeapify(arr, i);
  }
  return arr;
};

const data = line[1].split(' ').map(Number);
console.log(' ' + buildMaxHeap(data).join(' '));
