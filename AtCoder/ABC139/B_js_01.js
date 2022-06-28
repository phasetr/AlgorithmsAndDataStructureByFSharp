// https://atcoder.jp/contests/abc139/submissions/32143995
function solve(a,b){
  return Math.ceil((b-1)/(a-1));
}
const [[a,b]]=require("fs").readFileSync("/dev/stdin","utf8").trim().split("\n")
      .map(i=>i.trim().split(/\s+/).map(i=>isNaN(i)?i:i-0));
console.log(solve(a,b));
