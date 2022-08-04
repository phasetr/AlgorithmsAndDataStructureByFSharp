// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/1268282/miraikako/JavaScript
function move(d1,d2,d3,d4,d5,d6){
  const x = this.toString();
  if(x==="N"){return [d2,d6,d3,d4,d1,d5];}
  if(x==="E"){return [d4,d2,d1,d6,d5,d3];}
}
function roll(d1,d2,d3,d4,d5,d6){
  return [d1,d3,d5,d2,d4,d6];
}
function rolls(arr){
  for(let i=0;i<4;i++){
    obj[arr.join(",")] = true;
    arr = roll.apply(null,arr);
  }
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = (input.trim()).split("\n");
const n = Arr.shift()-0;
const OBJ = {};
const result = "Yes";
for(let i=0;i<n;i++){
   const obj = {};
   const dice = Arr[i].split(" ").map(Number);
   for(let j=0;j<4;j++){
      rolls(dice);
      dice = move.apply("N",dice);
   }
   dice=move.apply("E",dice);
   rolls(dice);
   dice=move.apply("E",dice);
   dice=move.apply("E",dice);
   rolls(dice);
   for(let k in obj){
      if(OBJ.hasOwnProperty(k)){result= "No";}
      else OBJ[k]=true;
   }
   if(result=="No"){break;}
}
console.log(result);
