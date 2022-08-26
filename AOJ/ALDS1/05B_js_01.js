// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2670825/enoyo/JavaScript
process.stdin.resume();
process.stdin.setEncoding('utf8');
let input = '';
process.stdin.on('data', function(chunk) {input += chunk;});
process.stdin.on('end', function() {main(input.split("\n"));});

let count = 0;

function merge(A,left,mid,right) {
  let n1 = mid - left;
  let n2 = right - mid;
  let L = [];
  let R = [];
  for (let i = 0; i < n1; i++) L.push(A[left+i]);
  for (let i = 0; i < n2; i++) R.push(A[mid+i]);
  L.push(Number.MAX_SAFE_INTEGER);
  R.push(Number.MAX_SAFE_INTEGER);

  let i = 0,j = 0;
  for (let k = left; k < right; k++) {
    if (L[i] < R[j]) A[k] = L[i++];
    else A[k] = R[j++];
    count++;
  }
}

function mergeSort(A,left,right,count) {
  if (left + 1 >= right) return;
  let mid = Math.floor((left + right) / 2);
  mergeSort(A,left,mid);
  mergeSort(A,mid,right);
  merge(A,left,mid,right);
}

function main(lines) {
  let n = Number(lines[0]);
  let A = lines[1].split(" ").map(Number);
  mergeSort(A,0,n);

  console.log(A.join(" "));
  console.log(count);
}
