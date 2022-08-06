// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/6203678/RikiaR/JavaScript
(inputs=>{
  function isPrime(n){
    if(n===2) {return true;}
    if(n%2===0) {return false;}
    const r=Math.sqrt(n);
    for(let i=3;i<=r;i+=2){
      if(n%i===0) {return false;}
    }
    return true;
  }
  const len=Number(inputs[0]),cnt=0;
  for(let i=1;i<=len;i++){
    if(isPrime(Number(inputs[i]))) {cnt++;}
  }
  console.log(cnt);
})(require("fs").readFileSync("/dev/stdin","utf-8").trim("\n").split("\n"));
