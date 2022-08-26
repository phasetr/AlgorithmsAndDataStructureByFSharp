// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2710388/kaz2ngt/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');

const list = input.trim().split('\n');
const n = Number(list[0]);
const A = list[1].trim().split(' ');
const q = Number(list[2]);
const mi = list[3].trim().split(' ');

const dp = {};
const memo = (i, sum) => {
  dp[sum] = true;
  if (i === n) {
    return true;
  }
  memo(i + 1, sum);
  memo(i + 1, sum + Number(A[i]));
}
memo(0, 0);

for (let i = 0; i < q; i++) {
  console.log(dp[mi[i]] ? 'yes' : 'no');
}
