// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/1221706/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split(" ").map(Number);
const a = Arr[0];
const b = Arr[1];
const C = Arr[2];
const x = C*Math.PI/180;
const S = 1/2*a*b*Math.sin(x);
const L = a+b+Math.sqrt(a*a+b*b-2*a*b*Math.cos(x));
const h = b*Math.sin(x);
console.log(S.toFixed(4));
console.log(L.toFixed(4));
console.log(h.toFixed(4));
