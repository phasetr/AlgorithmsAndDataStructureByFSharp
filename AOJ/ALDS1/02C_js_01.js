// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/1339504/miraikako/JavaScript
function bubbleSort(A,N){
  for(let i=0;i<N;i++){
    for(let j=N-1;j>=i+1;j--){
      if(A[j][1]<A[j-1][1]){
        const memo=A[j];
        A[j]=A[j-1];
        A[j-1]=memo;
      }
    }
  }
}
function selectionSort(A,N){
  for(let i=0;i<N;i++){
    const minj=i;
    for(let j=i;j<N;j++){
      if(A[j][1]<A[minj][1])minj=j;
    }
    const memo=A[i];
    A[i]=A[minj];
    A[minj]=memo;
  }
}
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
const n=Arr.shift()-0;
const arr=Arr.shift().split(" ");
const arrA=arr.map(function(v){return v.split("");});
const arrB=arr.map(function(v){return v.split("");});
bubbleSort(arrA,n);
selectionSort(arrB,n);
console.log(arrA.join(" ").replace(/,/g,""));
console.log("Stable");
console.log(arrB.join(" ").replace(/,/g,""));
console.log((arrA.join(" ")===arrB.join(" "))?"Stable":"Not stable");
