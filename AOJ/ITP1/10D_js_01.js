// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/1268345/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const n = Arr[0]-0;
const x = Arr[1].split(" ").map(Number);
const y = Arr[2].split(" ").map(Number);
const sum1 = 0;
const sum2 = 0;
const sum3 = 0;
const max = 0;
for(let i = 0;i<n;i++){
   const a = Math.abs(x[i]-y[i]);
   sum1 += a;
   sum2 += Math.pow(a,2);
   sum3 += Math.pow(a,3);
   max = Math.max(max,a);
}
console.log(sum1.toFixed(6));
console.log(Math.sqrt(sum2).toFixed(6));
console.log(Math.pow(sum3,1/3).toFixed(6));
console.log(max.toFixed(6));
