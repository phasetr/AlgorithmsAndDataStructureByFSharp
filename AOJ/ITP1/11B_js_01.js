// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B/review/1225299/miraikako/JavaScript
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

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const dice = Arr[0].split(" ").map(Number);
Arr.shift();
Arr.shift();
const NSEW = "NSEW".split("");

Arr.forEach(function(v){
  const a = (v.split(" "))[0]-0;
  const b = (v.split(" "))[1]-0;
  while(!(dice[0]===a && dice[1]===b)){
    const r = Math.floor(Math.random () * 4) ;
    dice = move(NSEW[r],dice);
  }
  console.log(dice[2]);
});
