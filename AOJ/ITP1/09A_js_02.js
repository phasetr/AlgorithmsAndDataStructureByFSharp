// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/6192107/RikiaR/JavaScript
((inputs)=>{
  const w=inputs[0];
  let res=0;
  const len = inputs.length-1;
  for(let i=1;i<len;i++){
    inputs[i].split(" ").forEach((item)=>{
      if(item.toLocaleLowerCase()===w) {res++;}
    });
  }
  console.log(res);
})(require("fs").readFileSync("/dev/stdin","utf-8").trim("\n").split("\n"));
