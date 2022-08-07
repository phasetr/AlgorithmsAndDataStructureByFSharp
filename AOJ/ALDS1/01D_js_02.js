// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/6400063/RikiaR/JavaScript
(inputs=>{
  const n = Number(shift(inputs));
  const ra = inputs;
  const min=ra[0],max=ra[1]-ra[0];
  for(const r in ra){
    max = Math.max(max,r-min);
    min = Math.min(min,r);
  }
  console.log(max);
})(require("fs").readFileSync("/dev/stdin","utf-8").trim("\n").split("\n"));
