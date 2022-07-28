// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/1220530/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const arr = Arr[0].split(" ").map(Number);
const a = Math.pow(arr[2]-arr[0],2)+Math.pow(arr[3]-arr[1],2);
const b = Math.sqrt(a,2);
const c = b.toFixed(4);
console.log(c);
