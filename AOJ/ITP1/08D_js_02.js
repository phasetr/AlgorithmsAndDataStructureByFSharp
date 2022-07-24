// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/6204897/RikiaR/JavaScript
(inputs=>{
  let p=inputs[0],s=inputs[1];
  p+=p;
  console.log( p.includes(s)?"Yes":"No" );
})(require("fs").readFileSync("/dev/stdin","utf-8").trim("\n").split("\n"));
