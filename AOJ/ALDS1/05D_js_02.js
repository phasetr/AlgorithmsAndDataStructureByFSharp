// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/6214774/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");
const n = parseInt(lines[0]);
const count = 0;
const A = lines[1].split(" ").map(Number);

function Merge(left,mid,right){
  const n1 = mid - left;
  const n2 = right - mid;
  const L = new Array(n1 + 1),R = new Array(n2 + 1);
  for(let i = 0;i < n1;i++) {L[i] = A[left + i];}
  for(let i = 0;i < n2;i++) {R[i] = A[mid + i];}
  L[n1] = Infinity;
  R[n2] = Infinity;
  const i = 0;
  const j = 0;
  for(let k = left;k < right;k++){
    if(L[i] <= R[j]) {
      A[k] = L[i++];
    } else if (L[i] > R[j]) {
      A[k] = R[j++];
      count += n1-i;
    }
  }
}

function MergeSort(left,right){
  if(left + 1< right){
    const mid = Math.floor((left + right)/2);
    MergeSort(left,mid);
    MergeSort(mid,right);
    Merge(left,mid,right);
  }
}

MergeSort(0,n);
console.log(count);
