// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/1229070/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
Arr.shift();
const obj={};
Arr.forEach(function(v){
  const arr=v.split(" ");
  if(arr[0]=="insert"){obj[arr[1]]=true;}
  if(arr[0]=="find"){console.log(obj.hasOwnProperty(arr[1]) ? "yes":"no");}
});
