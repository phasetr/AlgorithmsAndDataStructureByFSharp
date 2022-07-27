// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/1220476/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const str = Arr[0];
Arr.shift();
Arr.shift();
Arr.forEach(function(v){
   const arr = v.split(" ");
   const ab = arr[0];
   const a = arr[1]-0;
   const b = arr[2]-0;
   if (ab === "print") {console.log(str.slice(a,b+1));}
   if (ab === "reverse") {str = str.slice(0,a)+str.slice(a,b+1).split("").reverse().join("")+str.slice(b+1);}
   if (ab === "replace") {str = str.slice(0,a)+arr[3]+str.slice(b+1);}
});
