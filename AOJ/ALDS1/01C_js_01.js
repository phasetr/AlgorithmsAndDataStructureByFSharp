// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/1229037/miraikako/JavaScript
function isprime(x){
  if(x==2){return true;}
  if(x<2 || x%2==0){return false;}
  const i=3;
  while(i<=Math.sqrt(x)){
    if(x%i==0)return false;
    i=i+2;
  }
  return true;
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n").map(Number);
Arr.shift();
const cnt=0;
Arr.forEach(function(v){
  if(isprime(v)){cnt++;}
});
console.log(cnt);
