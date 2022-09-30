// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/941995/mihchang/JavaScript
function gcd(a, b) {
  if (b > a) { return gcd(b, a); }
  if (b == 0) { return a; }
  return gcd(b, a % b);
}
function lcm(a, b) {
  const d = gcd(a, b);
  return a * b / d;
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
const lines = input.split('\n');
const n = +lines.shift();
const nums = lines.shift().split(' ').map(function(num){return +num;});
let p = 1;
for (let i = 0; i < n; i++) {
  p = lcm(p, nums[i]);
}
console.log(p);
