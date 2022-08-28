// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/2304520/kyawakyawa/JavaScript
const s,n;
let count;

function Merge(left,mid,right){
  const n1 = mid - left;
  const n2 = right - mid;
  const L = new Array(n1 + 1),R = new Array(n2 + 1);
  for(let i = 0;i < n1;i++) {L[i] = s[left + i];}
  for(let i = 0;i < n2;i++) {R[i] = s[mid + i];}
  L[n1] = 2000000000;
  R[n2] = 2000000000;
  const i = 0;
  const j = 0;
  for(let k = left;k < right;k++){
    if(L[i] <= R[j])
      s[k] = L[i++];
    else{
      s[k] = R[j++];
      count += n1 - i;
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

function Main(input){
  input = input.split("\n");
  n = parseInt(input[0],10);
  s = new Array(n);
  input[1] = input[1].split(" ");
  for(let i = 0;i < n;i++){
    s[i] = parseInt(input[1][i],10);
  }
  count = 0;
  MergeSort(0,n);
  console.log(count);
}

Main(require("fs").readFileSync("/dev/stdin","utf8"));
