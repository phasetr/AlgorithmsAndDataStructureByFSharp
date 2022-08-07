// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/1223469/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n").map(Number);
Arr.shift();
const min = Arr[0];
const fx = Arr[1]-Arr[0];
Arr.shift();
Arr.forEach(function(v){
  fx = Math.max(fx,v-min);
  min = Math.min(min,v);
});
console.log(fx);
