// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/1223028/miraikako/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr = input.split("\n");
const A = Arr[1].split(" ").map(Number);
const N = Arr[0]-0;
console.log(A.join(" "));
for(let i=1;i<=N-1;i++){
  const v = A[i];
  const j = i-1;
  while(j>=0 && A[j]>v){
    A[j+1] = A[j];
    j--;
  }
  A[j+1] = v;
  console.log(A.join(" "));
}
