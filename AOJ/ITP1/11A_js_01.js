// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/1225278/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const dice = Arr[0].split(" ").map(Number);
const nsew = Arr[1].split("");

function move(x,arr){
  const d1 = arr[0];
  const d2 = arr[1];
  const d3 = arr[2];
  const d4 = arr[3];
  const d5 = arr[4];
  const d6 = arr[5];
  const after = [];
  if(x==="N"){after = [d2,d6,d3,d4,d1,d5];}
  if(x==="S"){after = [d5,d1,d3,d4,d6,d2];}
  if(x==="E"){after = [d4,d2,d1,d6,d5,d3];}
  if(x==="W"){after = [d3,d2,d6,d1,d5,d4];}
  return after;
}

nsew.forEach(function(v){
  dice = move(v,dice);
});
console.log(dice[0]);
