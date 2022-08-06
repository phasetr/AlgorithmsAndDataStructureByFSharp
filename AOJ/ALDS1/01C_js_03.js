// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/5084163/jj_/JavaScript
function isPrime(a) {
  for (let i=2; i<=Math.sqrt(a); i++) {
    if (a % i == 0) { return false; }
  }
  return true;
}

const input = require("fs").readFileSync("/dev/stdin/", "utf8").split("\n");
const n = parseInt(input[0]);
const ans = 0;
for(let i=1; i<=n; i++) {
  if (isPrime(parseInt(input[i]))) { ans += 1; }
}
console.log(ans);
