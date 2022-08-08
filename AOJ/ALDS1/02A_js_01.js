// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/1244905/miraikako/JavaScript
function bubbleSort(A){
  const N=A.length;
  const flag=1;
  const i=0;
  const cnt=0;
  while(flag==1){
    flag=0;
    for(let j=N-1;j>=i+1;j--){
      if(A[j]<A[j-1]){
        const m=A[j];
        A[j]=A[j-1];
        A[j-1]=m;
        flag=1;
        cnt++;
      }
    }
    i++;
  }
  return [A,cnt];
}

const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const Arr=(input.trim()).split("\n");
Arr.shift();
const arr=Arr[0].split(" ").map(Number);
const result=bubbleSort(arr);
console.log(result[0].join(" "));
console.log(result[1]);
