// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1219346/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
const a=Arr[0]+Arr[0]+Arr[0];
const b=Arr[1];
console.log((a.indexOf(b)!==-1)?"Yes":"No");
