// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/1339478/miraikako/JavaScript
function selectionSort(A,N){
  for(let i=0;i<N;i++){
    const minj=i;
    for(const j=i;j<N;j++){
      if(A[j]<A[minj]){minj=j;}
    }
    if(A[i]!=A[minj]){cnt++;}
    const memo=A[i];
    A[i]=A[minj];
    A[minj]=memo;
  }
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
const n=Arr.shift()-0;
const arr=Arr.shift().split(" ").map(Number);
const cnt=0;
selectionSort(arr,n);
console.log(arr.join(" "));
console.log(cnt);
