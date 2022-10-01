// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/942031/mihchang/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var num = +input;

var result = num;
if (num % 2 == 0) {
  result /= 2;
  while (num % 2 == 0) {
    num /= 2;
  }
}

var d = 3;
while (num / d >= d) {
  if (num % d == 0) {
    result = Math.floor(result / d);
    result *= d - 1;
    while (num % d == 0) {
      num /= d;
    }
  }
  d += 2;
}

if (num > 1) {
  result = Math.floor(result / num);
  result *= num - 1;
}
console.log(result);
