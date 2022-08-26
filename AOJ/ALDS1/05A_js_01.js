// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/1332769/miraikako/JavaScript
function solve(i,m){
   if(m==0)return true;
   if(i>=n)return false;
   return solve(i+1,m) || solve(i+1,m-A[i]);
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
const n=Arr.shift()-0;
const A=(Arr.shift()).split(" ").map(Number);
const m=Arr.shift()-0;
const M=(Arr.shift()).split(" ").map(Number);
for(let i=0;i<m;i++){
   const ans=(solve(0,M[i]))?"yes":"no";
   console.log(ans);
}
