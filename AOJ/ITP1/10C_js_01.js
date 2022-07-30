// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/1228899/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
for(let i=0; i<Arr.length; i=i+2){
  if (Arr[i]==="0") {break;}
  const val = Arr[i+1];
  const arr = val.split(" ").map(Number);
  const sum = arr.reduce(function(a,b){return a+b;});
  const ave = sum/arr.length;
  const a = 0;
  arr.forEach(function(v){
    a += Math.pow(v-ave,2);
  });
  console.log(Math.sqrt(a/arr.length).toFixed(4));
}
