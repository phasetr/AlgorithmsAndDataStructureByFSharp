// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3782284/kk5/JavaScript
function solve(n){
  function frec(i,x,acc){
    if (i*i>n) {
      if (x===1) { return acc; } else { acc.push(x); return acc; }
    } else if (x%i === 0) { acc.push(i); return frec(i,x/i,acc); }
    else { return frec(i+1,x,acc); }
  }
  return frec(2,n,[]);
}
const n = Number(require('fs').readFileSync('/dev/stdin', 'utf8'));
const arr = solve(n);
console.log(n + ': ' + arr.join(' '));

console.log(solve(12)); // [2,2,3]
console.log((solve(126))); // [2,3,3,7]
