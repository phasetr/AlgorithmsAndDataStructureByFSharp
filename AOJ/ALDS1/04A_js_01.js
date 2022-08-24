// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/4820157/YoshinoriN/JavaScript
const x = require('fs').readFileSync('/dev/stdin', 'utf8').split("\n");
const listA = Array.from(new Set(x[1].split(" ")));
const listB = Array.from(new Set(x[3].split(" ")));
let cnt = 0;
listB.forEach(x => {
  for (i = 0; listA.length > i; i++) {
    if (listA[i] === x) {
      cnt++;
    }
  }
});
console.log(cnt);
