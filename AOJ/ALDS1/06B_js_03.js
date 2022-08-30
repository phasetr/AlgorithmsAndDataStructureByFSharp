// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/6215503/sara3wati_3333/JavaScript
const input = require('fs').readFileSync('/dev/stdin', 'utf8');
const lines = (input.trim()).split("\n");
const n = parseInt(lines[0]);
const A = lines[1].split(" ")
    .map(Number);
function partition (A,p,r) {
  const x = A[r];
  i = p-1;
  for (let j = p; j < r; j++) {
    if (A[j] <= x) {
      i++;
      const B = A[i];
      A[i] = A[j];
      A[j] = B;
    }
  }
  B = A[i+1];
  A[i+1] = x;
  A[r] = B;
  return i+1;
}

const id = partition(A,0,n-1);
A[id] = "[" + A[id] + "]";
console.log(A.join(" "));
