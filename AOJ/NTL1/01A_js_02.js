// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3782284/kk5/JavaScript
let input = require('fs').readFileSync('/dev/stdin', 'utf8');
input = Number(input);
const arr = [];
const isPrime = num => {
  let flag = 1;
  for(let i = 2; i <= Math.sqrt(num); i++){
    if(num % i === 0) {
      flag = 0;
      break;
    }
  }
  return flag;
};
const factorize = n => {
  if(isPrime(n)) {
    arr.push(n);
  } else {
    for(let i = 2; i <= Math.sqrt(n); i++) {
      if(isPrime(i) && n % i === 0) {
        arr.push(i);
        factorize(n / i);
        break;
      }
    }
  }
};
factorize(input);
console.log(input + ': ' + arr.join(' '));
