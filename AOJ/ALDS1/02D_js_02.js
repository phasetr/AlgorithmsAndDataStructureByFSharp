// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/5674037/ochio/JavaScript
'use strict';

let cnt = 0;
function Main(input) {
  input = input.split('\n');
  const n = Number(input[0]);
  const ary = [];
  for (let i = 0; i < n; i++) {
    ary.push(Number(input[i + 1]));
  }
  shellSort(ary, n);
}

function insertionSort(A, n, g) {
  for (let i = g; i < n; i++) {
    const v = A[i];
    let j = i - g;
    while (j >= 0 && A[j] > v) {
      A[j + g] = A[j];
      j = j - g;
      cnt++;
    }
    A[j + g] = v;
  }
  return A;
}

function shellSort(A, n) {
  let G = [];
  for (let i = 1; Math.pow(2, i) - 1 <= n; i++) {
    G.push(Math.pow(2, i) - 1);
  }
  const m = G.length;
  G.reverse();
  for (let i = 0; i < m; i++) {
    insertionSort(A, n, G[i]);
  }
  console.log(m);
  console.log(G.join(' '));
  console.log(cnt);
  console.log(A.join('\n'));
}

Main(require('fs').readFileSync('/dev/stdin', 'utf8'));
