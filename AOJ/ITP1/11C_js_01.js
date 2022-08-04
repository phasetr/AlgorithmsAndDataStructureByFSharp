// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/1225326/miraikako/JavaScript
function move(x,arr){
  const d1 = arr[0];
  const d2 = arr[1];
  const d3 = arr[2];
  const d4 = arr[3];
  const d5 = arr[4];
  const d6 = arr[5];
  const after = [];
  if(x === "N"){after = [d2,d6,d3,d4,d1,d5];}
  if(x === "S"){after = [d5,d1,d3,d4,d6,d2];}
  if(x === "E"){after = [d4,d2,d1,d6,d5,d3];}
  if(x === "W"){after = [d3,d2,d6,d1,d5,d4];}
  return after;
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const diceA = Arr[0].split(" ").map(Number);
const diceB = Arr[1].split(" ").map(Number);
const NSEW = "NSEW".split("");

for(let i=0;i<100;i++){
  const r = Math.floor(Math.random () * 4) ;
  diceA = move(NSEW[r],diceA);
  const flag = diceA.every(function(v,i){return (v === diceB[i]);});
  if(flag){break;}
}
console.log(flag?"Yes":"No");
