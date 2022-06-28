// https://atcoder.jp/contests/abc156/submissions/31069035
function solve(n,xa) {
  const M = 100;
  xa.sort((a, b) => a - b);
  return [...Array(M+1)].map((_,i) => i)
    .map(p => xa.reduce((acc,x) => acc+(x-p)**2))
    .reduce((acc,x) => Math.min(acc,x));
}
const input = require("fs").readFileSync("/dev/stdin", "utf8").trim().split("\n");
const n = Number(input[0]);
const xa = input[1].split(" ").map(e => Number(e));
console.log(sort(n,xa));
