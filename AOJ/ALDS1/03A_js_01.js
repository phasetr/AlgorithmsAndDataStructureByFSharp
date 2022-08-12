// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/937243/mihchang/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const tokens = input.split(' ');
const stack = [];

tokens.forEach(function(token) {
  if (token - 0 == token) {
    stack.push(token);
  } else {
    const a = stack.pop();
    const b = stack.pop();
    stack.push(eval(b + token + a));
  }
});

console.log(stack.pop());
