// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/939968/mihchang/Javascript
const mem = [];
function fib(n) {
  if (mem[n]) return mem[n];
  if (n <= 1) return 1;
  mem[n] = fib(n - 1) + fib(n - 2);
  return mem[n];
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const n = +input.trim();
console.log(fib(n));
