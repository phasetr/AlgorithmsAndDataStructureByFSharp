// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/2411604/anndonut/JavaScript
//config = { input: 'tmp', newline: '\r\n' }; // win
config = { input: '/dev/stdin', newline: '\n' }; // linux

A = require('fs').readFileSync(config.input, 'ascii')
  .trim()
  .split(config.newline)
  .map(Number);
A.shift();

res = shellSort(A);
console.log(res.G.length);
console.log(res.G.join(' '));
console.log(res.cnt);
console.log(A.join('\n'));

function insertionSort(A, g) {
  let j;
  let v;
  let cnt = 0;
  for (let i = g; i < A.length; i++) {
    v = A[i];
    j = i - g;
    while (j >= 0 && A[j] > v) {
      A[j + g] = A[j];
      j = j - g;
      cnt++;
    }
    A[j + g] = v;
  }
  return cnt;
}

function shellSort(A) {
  let cnt = 0;
  const G = [1];
  for (let i = 2; i < A.length; i *= 2) {G.push(i);}
  G.reverse();
  for (const i in G) {cnt += insertionSort(A, G[i]);}
  return {'G': G, 'cnt': cnt};
}
