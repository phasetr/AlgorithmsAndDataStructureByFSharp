// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/943177/mihchang/JavaScript
function euc(a, b) {
  var r0 = a;
  var r1 = b;
  var x0 = 1;
  var x1 = 0;
  var y0 = 0;
  var y1 = 1;

  while (r1 > 0) {
    var q = Math.floor(r0 / r1);
    var r2 = r0 % r1;
    var x2 = x0 - q * x1;
    var y2 = y0 - q * y1;

    r0 = r1;
    r1 = r2;
    x0 = x1;
    x1 = x2;
    y0 = y1;
    y1 = y2;
  }
  return [x0, y0];
}

var input = require('fs').readFileSync('/dev/stdin', 'utf8').trim();
var nums = input.split(' ').map(function(num){return +num;});
var a = nums[0];
var b = nums[1];

console.log(euc(a, b).join(' '));
