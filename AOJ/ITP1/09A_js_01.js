// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/1219370/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
input=input.toLowerCase();
const Arr=(input.trim()).split("\n");
const W=Arr[0];
const ctn=0;
for(i=1;i<Arr.length;i++){
  if(Arr[i]==="END_OF_TEXT") {break;}
  const arr=Arr[i].split(" ");
  arr.forEach(function(v,i){
    if(v==W){ctn++;}
  });
}
console.log(ctn);
