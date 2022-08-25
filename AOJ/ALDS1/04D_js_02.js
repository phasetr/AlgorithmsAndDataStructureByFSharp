// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/2968919/s1250087/JavaScript
const line = require('fs').readFileSync('/dev/stdin', 'utf-8').split('\n');

const check = (arr, k, n, p) => {
  let i = 0;
  for (let j = 0; j < k; j++) {
    let s = 0;
    while(s + arr[i] <= p) {
      s += arr[i];
      i++;
      if (i === n) return n;
    }
  }
  return i;
};

const solve = (k, n, arr) => {
  let l = 0;
  let r = 100000 * 10000;
  while(r - l > 1) {
    let mid = Math.floor((l + r) / 2);
    const v = check(arr, k, n, mid);
    if (v >= n) r = mid;
    else l = mid;
  }
  return r;
};

const N = Number(line[0].split(' ')[0]);
const K = Number(line[0].split(' ')[1]);
const Arr = line.slice(1, N+1).map(Number);
console.log(solve(K, N, Arr));
