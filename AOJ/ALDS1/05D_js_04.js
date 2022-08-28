// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/2982432/s1250042/JavaScript
let cnt = 0;
(function main(){
  const lines = require('fs').readFileSync('/dev/stdin', 'utf8').trim().split('\n');
  const n = Number(lines.shift());
  let arr = lines.shift().split(' ').map(Number);
  mergeSort(arr, 0, n);
  // console.log(arr.join(' '));
  console.log(cnt);
})();

function merge(arr, left, mid, right) {
  let L = arr.slice(left, mid);
  let R = arr.slice(mid, right);
  L.push(Infinity);
  R.push(Infinity);
  let i = 0;
  let j = 0;
  let t = 0;
  for (let k = left; k < right; k++) {
    if (L[i] < R[j]) {
      arr[k] = L[i++];
      cnt += t;
    } else {
      arr[k] = R[j++];
      t += 1;
    }
  }
}

function mergeSort(arr, left, right) {
  if (left + 1 < right) {
    let mid = Math.floor((left + right) / 2);
    mergeSort(arr, left, mid);
    mergeSort(arr, mid, right);
    merge(arr, left, mid, right);
  }
}
