// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3321748/hothukurou2/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
//const input = 1463616;
const n = parseInt(input);
const on = n;

const primes = [];
while (n % 2 == 0) {
  primes.push(2);
  n = n / 2;
}
for (let i = 3; i <= Math.sqrt(n); i += 2) {
  while (n % i == 0) {
    primes.push(i);
    n /= i;
  }
}
if (n > 1) primes.push(n);

console.log(on + ': ' + primes.join(' '));
