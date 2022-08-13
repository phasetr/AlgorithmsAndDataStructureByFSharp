// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/1223269/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
const t=(Arr[0].split(" "))[1]-0;
Arr.shift();
const T=0;
const i=0;
while(Arr.length!=0){
   const arr=Arr[0].split(" ");
   Arr.shift();
   const a=arr[0];
   const b=arr[1]-0;
   if(b-t<=0){
      console.log(a+" "+(T+b));
      T+=b;
   }else{
      Arr.push(a+" "+(b-t));
      T+=t;
   }
}
