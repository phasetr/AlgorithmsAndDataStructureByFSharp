// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/3089480/miraikako/JavaScript
var input = require('fs').readFileSync('/dev/stdin', 'utf8');
var arr = input.trim().split("\n");
var Q=arr[0]-0;
var a=[];
var s="";
for(var i=1;i<=Q;i++){
   var q=arr[i].split(" ");
   if(q[0]=="0")a.push(q[1]-0);
   else if(q[0]=="1")s+=(a[q[1]]-0)+"\n";
   else a.pop();
}
console.log(s.trim());
