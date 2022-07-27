// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/1220446/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
Arr.shift();
const t=0;
const h=0;
Arr.forEach(function(v){
  const arr=v.split(" ");
  if (arr[0]==arr[1]) {t++;h++;}
  if (arr[0]>arr[1])  {t+=3;}
  if (arr[0]<arr[1])  {h+=3;}
});
console.log(t+" "+h);
